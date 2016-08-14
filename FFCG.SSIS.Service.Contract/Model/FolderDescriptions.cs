// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderDescriptions.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the FolderDescriptions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The folder descriptions.
    /// </summary>
    [CollectionDataContract(Name = "FolderDescriptions", Namespace = Constants.Namespace, ItemName = "FolderDescription")]
    public class FolderDescriptions : List<FolderDescription>
    {
        public FolderDescriptions()
        {
        }

        public FolderDescriptions(IEnumerable<FolderDescription> descriptions)
            : base(descriptions)
        {
        }
    }
}