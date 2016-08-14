// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageParameter.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the PackageParameter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The parameter.
    /// </summary>
    [DataContract(Name = "PackageParameter", Namespace = Constants.Namespace)]
    public class PackageParameter
    {
        /// <summary>
        /// Gets or sets the object type.
        /// </summary>
        [DataMember(Name = "ObjectType")]
        public ObjectType ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the parameter name.
        /// </summary>
        [DataMember(Name = "ParameterName")]
        public string ParameterName { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [DataMember(Name = "Value")]
        public string Value { get; set; }
    }
}