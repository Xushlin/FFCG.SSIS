// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationMessage.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The operation message.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Data.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The operation message.
    /// </summary>
    [Table("operation_messages", Schema = "catalog")]
    public class OperationMessage
    {
        /// <summary>
        /// Gets or sets the operation message id.
        /// </summary>
        [Column("operation_message_id")]
        [Key]
        public long OperationMessageId { get; set; }

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
        /// Gets or sets the operation.
        /// </summary>
        public virtual Operation Operation { get; set; }
    }
}