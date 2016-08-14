// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectDescription.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The project description.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The project description.
    /// </summary>
    [DataContract(Name = "ProjectDescription", Namespace = Constants.Namespace)]
    public class ProjectDescription
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the folder name.
        /// </summary>
        [DataMember(Name = "FolderName")]
        public string FolderName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [DataMember(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        [DataMember(Name = "CreatedTime")]
        public DateTimeOffset CreatedTime { get; set; }
    }
}