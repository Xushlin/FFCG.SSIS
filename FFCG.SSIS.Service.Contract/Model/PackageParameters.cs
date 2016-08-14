// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageParameters.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the PackageParameters type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The start PackageParameters.
    /// </summary>
    [CollectionDataContract(Name = "PackageParameters", Namespace = Constants.Namespace, ItemName = "PackageParameter")]
    public class PackageParameters : List<PackageParameter>
    {
        public PackageParameters()
        {
        }

        public PackageParameters(IEnumerable<PackageParameter> parameters)
            : base(parameters)
        {
        }
    }
}