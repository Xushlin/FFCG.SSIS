// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Operation.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the Operation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Data.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The operation.
    /// </summary>
    [Table("operations", Schema = "catalog")]
    public class Operation
    {
        /// <summary>
        /// Gets or sets the operation id.
        /// </summary>
        [Column("operation_id")]
        [Key]
        public long OperationId { get; set; }

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
        /// Gets or sets the object name.
        /// </summary>
        [Column("object_name")]
        [StringLength(260)]
        public string ObjectName { get; set; }

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
    }
}