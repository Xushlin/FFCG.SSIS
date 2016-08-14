// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoCConfig.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the IoCConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Web
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Web;

    using FFCG.SSIS.Tools.Logic.Implementation;

    using TinyIoC;

    /// <summary>
    /// The io c config.
    /// </summary>
    public static class IoCConfig
    {
        public static void Register(Configuration configuration)
        {
            var objectFactory = new ObjectProvider();

            // Get IoC container.
            var container = TinyIoCContainer.Current;

            var configurationSection = GetSection<InversionOfControlSection>("iocSection", configuration);
            foreach (var mapping in configurationSection.Mappings)
            {
                if (ReferenceEquals(mapping.Parameters, default(InversionOfControlSection.ParameterCollection)) || mapping.Parameters.Count == 0)
                {
                    var registerOptions = string.IsNullOrEmpty(mapping.Identifier)
                        ? container.Register(mapping.Interface, mapping.Implementation)
                        : container.Register(mapping.Interface, mapping.Implementation, mapping.Identifier);

                    if (mapping.Singleton)
                    {
                        registerOptions.AsSingleton();
                    }
                    else
                    {
                        registerOptions.AsMultiInstance();
                    }
                }
                else
                {
                    var implementation = mapping.Implementation;
                    var parameters = mapping.Parameters;

                    if (string.IsNullOrEmpty(mapping.Identifier))
                    {
                        container.Register(mapping.Interface, (c, np) => objectFactory.CreateByDictionaryType(implementation, parameters.ToDictionary(p => p.Name, p => (object)p.Value)));
                    }
                    else
                    {
                        container.Register(mapping.Interface, (c, np) => objectFactory.CreateByDictionaryType(implementation, parameters.ToDictionary(p => p.Name, p => (object)p.Value)), mapping.Identifier);
                    }
                }
            }

            // create an ioc binding for httpcontextbase since it is used for some controllers.
            container.Register<HttpContextBase>((c, o) => new HttpContextWrapper(HttpContext.Current));
        }

        private static T GetSection<T>(string sectionName, Configuration configuration) where T : ConfigurationSection
        {
            var o = configuration.GetSection(sectionName);
            if (ReferenceEquals(o, default(ConfigurationSection)))
            {
                throw new Exception($"Missing section {sectionName}");
            }

            var section = o as T;
            if (ReferenceEquals(section, default(T)))
            {
                throw new Exception($"Section {sectionName} was not of type {typeof(T).FullName} but of type {o.GetType().FullName}.");
            }

            return section;
        }
    }
}