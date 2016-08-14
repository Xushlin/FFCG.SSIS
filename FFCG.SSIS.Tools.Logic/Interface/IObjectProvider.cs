// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IObjectProvider.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The ObjectProvider interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Tools.Logic.Interface
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The ObjectProvider interface.
    /// </summary>
    public interface IObjectProvider
    {
        /// <summary>
        /// Creates a new instance of an object given the correct number of parameters.
        /// </summary>
        /// <param name="args">
        /// Arguments to the constructor.
        /// </param>
        /// <typeparam name="T">
        /// Object type to instantiate.
        /// </typeparam>
        /// <returns>
        /// A new instance of the object.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the parameters do not match the arguments to the method.
        /// </exception>
        T Create<T>(params object[] args);

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <typeparam name="T">
        /// Object type to instantiate.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T CreateByDictionary<T>(Dictionary<string, object> args);

        /// <summary>
        /// Creates a new instance of an object given the correct number of parameters.
        /// This is slower than the generics variant.
        /// </summary>
        /// <param name="type">
        /// Object type to instantiate.
        /// </param>
        /// <param name="args">
        /// Arguments to the constructor.
        /// </param>
        /// <returns>
        /// A new instance of the object.
        /// </returns>
        object CreateByDictionaryType(Type type, Dictionary<string, object> args);

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
        object CreateByType(Type type, params object[] args);

        /// <summary>
        /// The load types based on the given interface.
        /// </summary>
        /// <param name="interface">
        /// The interface.
        /// </param>
        /// <returns>
        /// The <see cref="Type[]"/>.
        /// </returns>
        Type[] LoadTypesBasedOn(Type @interface);
    }
}
