// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageDescription.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the PackageDescription type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System;
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
        /// Gets or sets the package guid.
        /// </summary>
        [DataMember(Name = "PackageGuid")]
        public Guid PackageGuid { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [DataMember(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the package format version.
        /// </summary>
        [DataMember(Name = "PackageFormatVersion")]
        public int PackageFormatVersion { get; set; }

        /// <summary>
        /// Gets or sets the version major.
        /// </summary>
        [DataMember(Name = "VersionMajor")]
        public int VersionMajor { get; set; }

        /// <summary>
        /// Gets or sets the version minor.
        /// </summary>
        [DataMember(Name = "VersionMinor")]
        public int VersionMinor { get; set; }

        /// <summary>
        /// Gets or sets the version build.
        /// </summary>
        [DataMember(Name = "VersionBuild")]
        public int VersionBuild { get; set; }

        /// <summary>
        /// Gets or sets the version comments.
        /// </summary>
        [DataMember(Name = "VersionComments")]
        public string VersionComments { get; set; }

        /// <summary>
        /// Gets or sets the version GUID.
        /// </summary>
        [DataMember(Name = "VersionGuid")]
        public Guid VersionGuid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether entry point.
        /// </summary>
        [DataMember(Name = "EntryPoint")]
        public bool EntryPoint { get; set; }

        /// <summary>
        /// Gets or sets the validation status.
        /// </summary>
        [DataMember(Name = "ValidationStatus")]
        public char ValidationStatus { get; set; }

        /// <summary>
        /// Gets or sets the last validation time.
        /// </summary>
        [DataMember(Name = "LastValidationTime")]
        public DateTimeOffset? LastValidationTime { get; set; }
    }
}