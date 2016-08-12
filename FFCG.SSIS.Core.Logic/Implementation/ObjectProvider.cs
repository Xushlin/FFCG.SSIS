// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectProvider.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the ObjectProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Logic.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using FFCG.SSIS.Core.Contract.Interface;

    /// <summary>
    /// The object provider.
    /// </summary>
    public class ObjectProvider : IObjectProvider
    {
        /// <summary>
        /// The object activator.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <typeparam name="T">
        /// Type that the activator creates.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        private delegate T ObjectActivator<out T>(params object[] args);

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <typeparam name="T">
        /// The type to construct.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// When the arguments does not match the constructor arguments.
        /// </exception>
        public T Create<T>(params object[] args)
        {
            // TODO: Select constructor by type of parameters, this will need to take into consideration derived type.
            var ctors = typeof(T).GetConstructors().Where(c => c.GetParameters().Length == args.Length);

            foreach (var ctor in ctors)
            {
                var isOk = true;
                var parameters = ctor.GetParameters();
                for (var i = 0; i < parameters.Length; ++i)
                {
                    isOk = parameters[i].ParameterType.IsInstanceOfType(args[i]) && isOk;
                }

                if (!isOk)
                {
                    continue;
                }

                var createdActivator = GetActivator<T>(ctor);
                return createdActivator(args);
            }

            throw new ArgumentException("Number of arguments did not match number of argumetns to constructor.");
        }

        /// <summary>
        /// The create by dictionary.
        /// </summary>
        /// <param name="argsDictionary">
        /// The args dictionary.
        /// </param>
        /// <typeparam name="T">
        /// The type to construct.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// When arguments does not match the constructor.
        /// </exception>
        public T CreateByDictionary<T>(Dictionary<string, object> argsDictionary)
        {
            var ctor = typeof(T).GetConstructors().FirstOrDefault(c => c.GetParameters().Length == argsDictionary.Count && c.GetParameters().All(p => argsDictionary.ContainsKey(p.Name)));

            if (ctor == default(ConstructorInfo))
            {
                throw new ArgumentException("Number of arguments did not match number of argumetns to constructor.");
            }

            var args = ctor.GetParameters().Select(p => argsDictionary[p.Name]).ToArray();

            var createdActivator = GetActivator<T>(ctor);
            return createdActivator(args);
        }

        /// <summary>
        /// The create by dictionary type.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object CreateByDictionaryType(Type type, Dictionary<string, object> args)
        {
            var method = typeof(ObjectProvider).GetMethod("CreateByDictionary").MakeGenericMethod(type);
            return method.Invoke(this, new object[] { args });
        }

        /// <summary>
        /// The create by type.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object CreateByType(Type type, params object[] args)
        {
            var method = typeof(ObjectProvider).GetMethod("Create").MakeGenericMethod(type);
            return method.Invoke(this, new object[] { args });
        }

        /// <summary>
        /// The load types based on.
        /// </summary>
        /// <param name="interface">
        /// The interface.
        /// </param>
        /// <returns>
        /// The <see cref="Type[]"/>.
        /// </returns>
        public Type[] LoadTypesBasedOn(Type @interface)
        {
            // hacks to avoid security issues for dynamically loaded assemblies.
            // We do not want to get exported types of AssemblyBuilder or InternalAssemblyBuilder
            // classes since they are limited by security.
            return AppDomain.CurrentDomain.GetAssemblies()
                    .Where(assembly => !(assembly is global::System.Reflection.Emit.AssemblyBuilder))
                    .Where(assembly => !assembly.GlobalAssemblyCache)
                    .Where(assembly => assembly.GetType().FullName != "System.Reflection.Emit.InternalAssemblyBuilder")
                    .SelectMany(asm => asm.GetTypes())
                    .Where(t => @interface.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                    .ToArray();
        }

        /// <summary>
        /// The get activator.
        /// </summary>
        /// <param name="ctor">
        /// The ctor.
        /// </param>
        /// <typeparam name="T">
        /// Type to construct.
        /// </typeparam>
        /// <returns>
        /// The <see cref="ObjectActivator"/>.
        /// </returns>
        private static ObjectActivator<T> GetActivator<T>(ConstructorInfo ctor)
        {
            var type = ctor.DeclaringType;
            var paramsInfo = ctor.GetParameters();

            // create a single param of type object[]
            var param = Expression.Parameter(typeof(object[]), "args");

            var argsExp = new Expression[paramsInfo.Length];

            // pick each arg from the params array 
            // and create a typed expression of them
            for (var i = 0; i < paramsInfo.Length; i++)
            {
                var index = Expression.Constant(i);
                var paramType = paramsInfo[i].ParameterType;
                var paramAccessorExp = Expression.ArrayIndex(param, index);

                Expression paramCastExp = Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }

            // make a NewExpression that calls the
            // ctor with the args we just created
            var newExp = Expression.New(ctor, argsExp);

            // create a lambda with the New
            // Expression as body and our param object[] as arg
            var lambda = Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

            // compile it
            var compiled = (ObjectActivator<T>)lambda.Compile();
            return compiled;
        }
    }
}