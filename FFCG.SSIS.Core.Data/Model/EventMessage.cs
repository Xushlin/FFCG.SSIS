// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventMessage.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the EventMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Data.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The event message.
    /// </summary>
    [Table("event_messages", Schema = "catalog")]
    public class EventMessage
    {
        /// <summary>
        /// Gets or sets the event message id.
        /// </summary>
        [Column("event_message_id")]
        [Key]
        public long EventMessageId { get; set; }

        /// <summary>
        /// Gets or sets the operation id.
        /// </summary>
        [Column("operation_id")]
        public long OperationId { get; set; }

        /// <summary>
        /// Gets or sets the message time.
        /// </summary>
        [Column("message_time")]
        public DateTimeOffset MessageTime { get; set; }

        /// <summary>
        /// Gets or sets the message type.
        /// </summary>
        [Column("message_type")]
        public short MessageType { get; set; }

        /// <summary>
        /// Gets or sets the message source type.
        /// </summary>
        [Column("message_source_type")]
        public short MessageSourceType { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [Column("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the extended info id.
        /// </summary>
        [Column("extended_info_id")]
        public long? ExtendedInfoId { get; set; }

        /// <summary>
        /// Gets or sets the package name.
        /// </summary>
        [Column("package_name")]
        [StringLength(260)]
        public string PackageName { get; set; }

        /// <summary>
        /// Gets or sets the event name.
        /// </summary>
        [Column("event_name")]
        [StringLength(1024)]
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the message source name.
        /// </summary>
        [Column("message_source_name")]
        [StringLength(4000)]
        public string MessageSourceName { get; set; }

        /// <summary>
        /// Gets or sets the message source id.
        /// </summary>
        [Column("message_source_id")]
        [StringLength(38)]
        public string MessageSourceId { get; set; }

        /// <summary>
        /// Gets or sets the subcomponent name.
        /// </summary>
        [Column("subcomponent_name")]
        [StringLength(4000)]
        public string SubcomponentName { get; set; }

        /// <summary>
        /// Gets or sets the package path.
        /// </summary>
        [Column("package_path")]
        public string PackagePath { get; set; }

        /// <summary>
        /// Gets or sets the execution path.
        /// </summary>
        [Column("execution_path")]
        public string ExecutionPath { get; set; }

        /// <summary>
        /// Gets or sets the thread id.
        /// </summary>
        [Column("threadID")]
        public int? ThreadId { get; set; }

        /// <summary>
        /// Gets or sets the message code.
        /// </summary>
        [Column("message_code")]
        public int? MessageCode { get; set; }

        /// <summary>
        /// Gets or sets the operation.
        /// </summary>
        public virtual Operation Operation { get; set; }
    }
}