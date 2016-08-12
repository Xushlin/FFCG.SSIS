// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Folder.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The folder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The folder.
    /// </summary>
    [Table("folders", Schema = "catalog")]
    public class Folder
    {
        public Folder()
        {
            this.Projects = new HashSet<Project>();
        }

        /// <summary>
        /// Gets or sets the folder id.
        /// </summary>
        [Column("folder_id")]
        [Key]
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
        /// Gets or sets the created by sid.
        /// </summary>
        [Column("created_by_sid")]
        [MaxLength(85)]
        public byte[] CreatedBySid { get; set; }

        /// <summary>
        /// Gets or sets the created by name.
        /// </summary>
        [Column("created_by_name")]
        [StringLength(128)]
        public string CreatedByName { get; set; }

        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        [Column("created_time")]
        public DateTimeOffset CreatedTime { get; set; }
        
        /// <summary>
        /// Gets or sets the projects.
        /// </summary>
        public virtual ICollection<Project> Projects { get; set; }
    }
}
