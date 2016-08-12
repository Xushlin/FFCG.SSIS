// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageDescription.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the PackageDescription type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.PackageRunner.Contract.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The package start description.
    /// </summary>
    [DataContract(Name = "PackageDescription", Namespace = Constants.Namespace)]
    public class PackageDescription
    {
        /// <summary>
        /// Gets or sets the package name.
        /// </summary>
        [DataMember(Name = "PackageName")]
        public string PackageName { get; set; }

        /// <summary>
        /// Gets or sets the folder name.
        /// </summary>
        [DataMember(Name = "FolderName")]
        public string FolderName { get; set; }

        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        [DataMember(Name = "ProjectName")]
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        [DataMember(Name = "Parameters")]
        public Parameters Parameters { get; set; }
    }
}