// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InversionOfControlSection.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The inversion of control section.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Tools.Logic.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    /// <summary>
    /// The inversion of control section.
    /// </summary>
    public class InversionOfControlSection : ConfigurationSection
    {
        /// <summary>
        /// The section name.
        /// </summary>
        public const string SectionName = "iocSection";

        /// <summary>
        /// The IOC mapping collection.
        /// </summary>
        public const string IocMappingCollectionName = "iocMappings";

        /// <summary>
        /// The IOC mapping name.
        /// </summary>
        public const string IocMappingName = "iocMapping";

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        [ConfigurationProperty(IocMappingCollectionName)]
        [ConfigurationCollection(typeof(IocMapping), AddItemName = IocMappingName)]
        public IocMappingCollection Mappings
        {
            get
            {
                return (IocMappingCollection)this[IocMappingCollectionName];
            }

            set
            {
                this[IocMappingCollectionName] = value;
            }
        }

        /// <summary>
        /// The company.
        /// </summary>
        public class IocMappingCollection : ConfigurationElementCollection, ICollection<IocMapping>
        {
            #region ICollection

            /// <summary>
            /// Gets a value indicating whether is read only.
            /// </summary>
            public new bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// The this.
            /// </summary>
            /// <param name="name">
            /// The name.
            /// </param>
            /// <returns>
            /// The <see cref="IocMapping"/>.
            /// </returns>
            public new IocMapping this[string name]
            {
                get
                {
                    return (IocMapping)this.BaseGet(name);
                }
            }

            /// <summary>
            /// The get enumerator.
            /// </summary>
            /// <returns>
            /// The <see cref="IEnumerator"/>.
            /// </returns>
            public new IEnumerator<IocMapping> GetEnumerator()
            {
                var ie = base.GetEnumerator();
                while (ie.MoveNext())
                {
                    yield return ie.Current as IocMapping;
                }
            }

            /// <summary>
            /// The add.
            /// </summary>
            /// <param name="item">
            /// The item.
            /// </param>
            public void Add(IocMapping item)
            {
                this.BaseAdd(item);
            }

            /// <summary>
            /// The clear.
            /// </summary>
            public void Clear()
            {
                this.BaseClear();
            }

            /// <summary>
            /// The contains.
            /// </summary>
            /// <param name="item">
            /// The item.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public bool Contains(IocMapping item)
            {
                return !object.ReferenceEquals(this[item.Name], default(IocMapping));
            }

            /// <summary>
            /// The copy to.
            /// </summary>
            /// <param name="array">
            /// The array.
            /// </param>
            /// <param name="arrayIndex">
            /// The array index.
            /// </param>
            public void CopyTo(IocMapping[] array, int arrayIndex)
            {
                var i = 0;
                foreach (var iocType in this)
                {
                    var index = arrayIndex + i;
                    if (array.Length >= index)
                    {
                        break;
                    }

                    array[index] = iocType;

                    ++i;
                }
            }

            /// <summary>
            /// The remove.
            /// </summary>
            /// <param name="item">
            /// The item.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public bool Remove(IocMapping item)
            {
                this.BaseRemove(item.Name);
                return true;
            }

            #endregion

            #region ConfigurationElementCollection

            /// <summary>
            /// The create new element.
            /// </summary>
            /// <returns>
            /// The <see cref="ConfigurationElement"/>.
            /// </returns>
            protected override ConfigurationElement CreateNewElement()
            {
                return new IocMapping();
            }

            /// <summary>
            /// The get element key.
            /// </summary>
            /// <param name="element">
            /// The element.
            /// </param>
            /// <returns>
            /// The <see cref="object"/>.
            /// </returns>
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((IocMapping)element).Name;
            }

            #endregion
        }

        /// <summary>
        /// The IOC type.
        /// </summary>
        public class IocMapping : ConfigurationElement
        {
            /// <summary>
            /// The register property name.
            /// </summary>
            private const string InterfacePropertyName = "interface";

            /// <summary>
            /// The identifier property name.
            /// </summary>
            private const string IdentifierPropertyName = "identifier";

            /// <summary>
            /// The implementation property name.
            /// </summary>
            private const string ImplementationPropertyName = "implementation";

            /// <summary>
            /// The parameter collection name.
            /// </summary>
            private const string ParameterCollectionName = "parameters";

            /// <summary>
            /// The parameter name.
            /// </summary>
            private const string ParameterName = "parameter";

            /// <summary>
            /// The singleton name.
            /// </summary>
            private const string SingletonPropertyName = "singleton";

            /// <summary>
            /// Gets the name.
            /// </summary>
            public string Name
            {
                get
                {
                    return (((string)this[IdentifierPropertyName]) ?? string.Empty) + (string)this[InterfacePropertyName];
                }
            }

            /// <summary>
            /// Gets or sets the register.
            /// </summary>
            [ConfigurationProperty(InterfacePropertyName, IsRequired = true)]
            public string InterfaceName
            {
                get
                {
                    return (string)this[InterfacePropertyName];
                }

                set
                {
                    this[InterfacePropertyName] = value;
                }
            }

            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            [ConfigurationProperty(IdentifierPropertyName, IsRequired = false)]
            public string Identifier
            {
                get
                {
                    return (string)this[IdentifierPropertyName];
                }

                set
                {
                    this[IdentifierPropertyName] = value;
                }
            }

            /// <summary>
            /// Gets or sets the implementation.
            /// </summary>
            [ConfigurationProperty(ImplementationPropertyName, IsRequired = true)]
            public string ImplementationName
            {
                get
                {
                    return (string)this[ImplementationPropertyName];
                }

                set
                {
                    this[ImplementationPropertyName] = value;
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether singleton.
            /// </summary>
            [ConfigurationProperty(SingletonPropertyName, IsRequired = false)]
            public bool Singleton
            {
                get
                {
                    return (bool)this[SingletonPropertyName];
                }

                set
                {
                    this[SingletonPropertyName] = value;
                }
            }

            /// <summary>
            /// Gets or sets the interface.
            /// </summary>
            public Type Interface
            {
                get
                {
                    return Type.GetType(this.InterfaceName);
                }

                set
                {
                    this.InterfaceName = value.AssemblyQualifiedName;
                }
            }

            /// <summary>
            /// Gets or sets the implementation.
            /// </summary>
            public Type Implementation
            {
                get
                {
                    return Type.GetType(this.ImplementationName);
                }

                set
                {
                    this.ImplementationName = value.AssemblyQualifiedName;
                }
            }

            /// <summary>
            /// Gets or sets the parameters.
            /// </summary>
            [ConfigurationProperty(ParameterCollectionName)]
            [ConfigurationCollection(typeof(Parameter), AddItemName = ParameterName)]
            public ParameterCollection Parameters
            {
                get
                {
                    return (ParameterCollection)this[ParameterCollectionName];
                }

                set
                {
                    this[ParameterCollectionName] = value;
                }
            }
        }

        /// <summary>
        /// The parameter.
        /// </summary>
        public class Parameter : ConfigurationElement
        {
            /// <summary>
            /// The register property name.
            /// </summary>
            private const string NamePropertyName = "name";

            /// <summary>
            /// The value property name.
            /// </summary>
            private const string ValuePropertyName = "value";
            
            /// <summary>
            /// Gets or sets the register.
            /// </summary>
            [ConfigurationProperty(NamePropertyName, IsRequired = true)]
            public string Name
            {
                get
                {
                    return (string)this[NamePropertyName];
                }

                set
                {
                    this[NamePropertyName] = value;
                }
            }

            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            [ConfigurationProperty(ValuePropertyName, IsRequired = true)]
            public string Value
            {
                get
                {
                    return (string)this[ValuePropertyName];
                }

                set
                {
                    this[ValuePropertyName] = value;
                }
            }
        }

        /// <summary>
        /// The parameter collection.
        /// </summary>
        public class ParameterCollection : ConfigurationElementCollection, ICollection<Parameter>
        {
            #region ICollection

            /// <summary>
            /// Gets a value indicating whether is read only.
            /// </summary>
            public new bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// The this.
            /// </summary>
            /// <param name="name">
            /// The name.
            /// </param>
            /// <returns>
            /// The <see cref="IocMapping"/>.
            /// </returns>
            public new Parameter this[string name]
            {
                get
                {
                    return (Parameter)this.BaseGet(name);
                }
            }

            /// <summary>
            /// The get enumerator.
            /// </summary>
            /// <returns>
            /// The <see cref="IEnumerator"/>.
            /// </returns>
            public new IEnumerator<Parameter> GetEnumerator()
            {
                var ie = base.GetEnumerator();
                while (ie.MoveNext())
                {
                    yield return ie.Current as Parameter;
                }
            }

            /// <summary>
            /// The add.
            /// </summary>
            /// <param name="item">
            /// The item.
            /// </param>
            public void Add(Parameter item)
            {
                this.BaseAdd(item);
            }

            /// <summary>
            /// The clear.
            /// </summary>
            public void Clear()
            {
                this.BaseClear();
            }

            /// <summary>
            /// The contains.
            /// </summary>
            /// <param name="item">
            /// The item.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public bool Contains(Parameter item)
            {
                return !object.ReferenceEquals(this[item.Name], default(Parameter));
            }

            /// <summary>
            /// The copy to.
            /// </summary>
            /// <param name="array">
            /// The array.
            /// </param>
            /// <param name="arrayIndex">
            /// The array index.
            /// </param>
            public void CopyTo(Parameter[] array, int arrayIndex)
            {
                var i = 0;
                foreach (var parameter in this)
                {
                    var index = arrayIndex + i;
                    if (array.Length >= index)
                    {
                        break;
                    }

                    array[index] = parameter;

                    ++i;
                }
            }

            /// <summary>
            /// The remove.
            /// </summary>
            /// <param name="item">
            /// The item.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public bool Remove(Parameter item)
            {
                this.BaseRemove(item.Name);
                return true;
            }

            #endregion

            #region ConfigurationElementCollection

            /// <summary>
            /// The create new element.
            /// </summary>
            /// <returns>
            /// The <see cref="ConfigurationElement"/>.
            /// </returns>
            protected override ConfigurationElement CreateNewElement()
            {
                return new Parameter();
            }

            /// <summary>
            /// The get element key.
            /// </summary>
            /// <param name="element">
            /// The element.
            /// </param>
            /// <returns>
            /// The <see cref="object"/>.
            /// </returns>
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((Parameter)element).Name;
            }

            #endregion
        }
    }
}
