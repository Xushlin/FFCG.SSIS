// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Package.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the Package type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;

namespace FFCG.SSIS.Core.Data.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The package.
    /// </summary>
    [Table("packages", Schema = "catalog")]
    public class Package
    {

        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        [Column("package_id")]
        public long PackageId { get; set; }
        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Column("name")]
        [StringLength(260)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the package GUID.
        /// </summary>
        [Column("package_guid")]
        public Guid PackageGuid { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Column("description")]
        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the package format version.
        /// </summary>
        [Column("package_format_version")]
        public int PackageFormatVersion { get; set; }

        /// <summary>
        /// Gets or sets the version major.
        /// </summary>
        [Column("version_major")]
        public int VersionMajor { get; set; }

        /// <summary>
        /// Gets or sets the version minor.
        /// </summary>
        [Column("version_minor")]
        public int VersionMinor { get; set; }

        /// <summary>
        /// Gets or sets the version build.
        /// </summary>
        [Column("version_build")]
        public int VersionBuild { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Column("version_comments")]
        [StringLength(1024)]
        public string VersionComments { get; set; }

        /// <summary>
        /// Gets or sets the version GUID.
        /// </summary>
        [Column("version_guid")]
        public Guid VersionGuid { get; set; }

        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        [Column("project_id")]
        public long ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether entry point.
        /// </summary>
        [Column("entry_point")]
        public bool EntryPoint { get; set; }

        /// <summary>
        /// Gets or sets the validation status.
        /// </summary>
        [Column("validation_status")]
        public char ValidationStatus { get; set; }

        /// <summary>
        /// Gets or sets the last validation time.
        /// </summary>
        [Column("last_validation_time")]
        public DateTimeOffset? LastValidationTime { get; set; }

        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        public virtual Project Project { get; set; }
    }
}