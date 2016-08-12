// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Project.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the Project type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Data.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The project.
    /// </summary>
    [Table("projects", Schema = "catalog")]
    public class Project
    {
        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        [Column("project_id")]
        [Key]
        public long ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the folder id.
        /// </summary>
        [Column("folder_id")]
        public long FolderId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Column("name")]
        [StringLength(128)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Column("description")]
        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the project format version.
        /// </summary>
        [Column("project_format_version")]
        public int? ProjectFormatVersion { get; set; }
        
        /// <summary>
        /// Gets or sets the stopped by sid.
        /// </summary>
        [Column("deployed_by_sid")]
        [MaxLength(85)]
        public byte[] DeployedBySid { get; set; }

        /// <summary>
        /// Gets or sets the stopped by name.
        /// </summary>
        [Column("deployed_by_name")]
        [StringLength(128)]
        public string DeployedByName { get; set; }

        /// <summary>
        /// Gets or sets the last deployed time.
        /// </summary>
        [Column("last_deployed_time")]
        public DateTimeOffset LastDeployedTime { get; set; }

        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        [Column("created_time")]
        public DateTimeOffset CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the object version.
        /// </summary>
        [Column("object_version_lsn")]
        public long ObjectVersion { get; set; }

        /// <summary>
        /// Gets or sets the validation status.
        /// </summary>
        [Column("validation_satus")]
        public char ValidationStatus { get; set; }

        /// <summary>
        /// Gets or sets the last validation time.
        /// </summary>
        [Column("last_validation_time")]
        public DateTimeOffset? LastValidationTime { get; set; }
    }
}