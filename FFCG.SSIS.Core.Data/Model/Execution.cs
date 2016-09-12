using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FFCG.SSIS.Core.Data.Model
{
    [Table("executions", Schema = "catalog" )]
    public class Execution
    {
        //[execution_id]
        [Column("execution_id")]
        [Key]
        public long ExecutionId { get; set; }

        //,[folder_name]
        [Column("folder_name")]
        [StringLength(128)]
        [Required]
        public string FolderName { get; set; }

        //,[project_name]
        [Column("project_name")]
        [StringLength(128)]
        [Required]
        public string ProjectName { get; set; }

        //,[package_name]
        [Column("package_name")]
        [StringLength(260)]
        [Required]
        public string PackageName { get; set; }

        //,[reference_id]
        [Column("reference_id")]
        public long? ReferenceId { get; set; }

        //,[reference_type]
        [Column("reference_type")]
        public char? ReferenceType { get; set; }

        //,[environment_folder_name]
        [Column("environment_folder_name")]
        [StringLength(128)]
        public string EnvironmentFolderName { get; set; }

        //,[environment_name]
        [Column("environment_name")]
        [StringLength(128)]
        public string EnvironmentName { get; set; }

        //,[project_lsn]
        [Column("project_lsn")]
        public long? ProjectLsn { get; set; }

        //,[executed_as_sid]
        [Column("executed_as_sid")]
        public byte[] ExecutedAsSid { get; set; }

        //,[executed_as_name]
        [Column("executed_as_name")]
        [StringLength(128)]
        public string ExecutedAsName { get; set; }

        [Column("use32bitruntime")]
        public bool Use32BitRuntime { get; set; }


        /// <summary>
        /// Gets or sets the operation type.
        /// </summary>
        [Column("operation_type")]
        public short OperationType { get; set; }


        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        [Column("created_time")]
        public DateTimeOffset? CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the object type.
        /// </summary>
        [Column("object_type")]
        public short? ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the object id.
        /// </summary>
        [Column("object_id")]
        public long? ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [Column("status")]
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        [Column("start_time")]
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        [Column("end_time")]
        public DateTimeOffset? EndTime { get; set; }


        /// <summary>
        /// Gets or sets the caller sid.
        /// </summary>
        [Column("caller_sid")]
        [MaxLength(85)]
        public byte[] CallerSid { get; set; }

        /// <summary>
        /// Gets or sets the caller name.
        /// </summary>
        [Column("caller_name")]
        [StringLength(128)]
        [Required]
        public string CallerName { get; set; }

        /// <summary>
        /// Gets or sets the process id.
        /// </summary>
        [Column("process_id")]
        public int? ProcessId { get; set; }

        /// <summary>
        /// Gets or sets the stopped by sid.
        /// </summary>
        [Column("stopped_by_sid")]
        [MaxLength(85)]
        public byte[] StoppedBySid { get; set; }

        /// <summary>
        /// Gets or sets the stopped by name.
        /// </summary>
        [Column("stopped_by_name")]
        [StringLength(128)]
        public string StoppedByName { get; set; }


        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
        [Column("server_name")]
        [StringLength(128)]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the machine name.
        /// </summary>
        [Column("machine_name")]
        [StringLength(128)]
        public string MachineName { get; set; }

        public virtual Operation Operation { get; set; }

        //,[total_physical_memory_kb]
        //,[available_physical_memory_kb]
        //,[total_page_file_kb]
        //,[available_page_file_kb]
        //,[cpu_count]
    }
}