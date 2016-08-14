// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectDescriptions.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the ProjectDescriptions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The project descriptions.
    /// </summary>
    [CollectionDataContract(Name = "ProjectDescriptions", Namespace = Constants.Namespace, ItemName = "ProjectDescription")]
    public class ProjectDescriptions : List<ProjectDescription>
    {
        public ProjectDescriptions()
        {
        }

        public ProjectDescriptions(IEnumerable<ProjectDescription> descriptions)
            : base(descriptions)
        {
        }
    }
}