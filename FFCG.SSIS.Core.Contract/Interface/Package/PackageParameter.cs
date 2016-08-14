// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageParameter.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the PackageParameter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Package
{
    using FFCG.SSIS.Core.Contract.Interface.Operation;

    /// <summary>
    /// The package parameter.
    /// </summary>
    public class PackageParameter
    {
        /// <summary>
        /// Gets or sets the object type.
        /// </summary>
        public ObjectType ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the parameter name.
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }
    }
}
