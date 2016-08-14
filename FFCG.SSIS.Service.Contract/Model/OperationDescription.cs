// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationDescription.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the OperationDescription type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The operation description.
    /// </summary>
    [DataContract(Name = "OperationDescription", Namespace = Constants.Namespace)]
    public class OperationDescription
    {
        /// <summary>
        /// Gets or sets the operation id.
        /// </summary>
        [DataMember(Name = "OperationId")]
        public long OperationId { get; set; }

        /// <summary>
        /// Gets or sets the operation type.
        /// </summary>
        [DataMember(Name = "OperationType")]
        public OperationType OperationType { get; set; }

        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        [DataMember(Name = "CreatedTime")]
        public DateTimeOffset? CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the object type.
        /// </summary>
        [DataMember(Name = "ObjectType")]
        public ObjectType? ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [DataMember(Name = "Status")]
        public OperationStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        [DataMember(Name = "StartTime")]
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        [DataMember(Name = "EndTime")]
        public DateTimeOffset? EndTime { get; set; }
    }
}