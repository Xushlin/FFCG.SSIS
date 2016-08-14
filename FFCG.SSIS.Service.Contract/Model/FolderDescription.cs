// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderDescription.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the FolderDescription type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The folder description.
    /// </summary>
    [DataContract(Name = "FolderDescription", Namespace = Constants.Namespace)]
    public class FolderDescription
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "Name")]
        public string Name { get; set; }

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