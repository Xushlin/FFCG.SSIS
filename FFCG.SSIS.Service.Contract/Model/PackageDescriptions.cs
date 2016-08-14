// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageDescriptions.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the PackageDescriptions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The package descriptions.
    /// </summary>
    [CollectionDataContract(Name = "PackageDescriptions", Namespace = Constants.Namespace, ItemName = "PackageParameter")]
    public class PackageDescriptions : List<PackageDescription>
    {
        public PackageDescriptions()
        {
        }

        public PackageDescriptions(IEnumerable<PackageDescription> descriptions)
            : base(descriptions)
        {
        }
    }
}