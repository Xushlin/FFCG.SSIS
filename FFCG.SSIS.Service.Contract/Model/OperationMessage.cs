// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationMessage.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the OperationMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The operation message.
    /// </summary>
    [DataContract(Name = "OperationMessage", Namespace = Constants.Namespace)]
    public class OperationMessage
    {
        /// <summary>
        /// Gets or sets the message time.
        /// </summary>
        [DataMember(Name = "MessageTime")]
        public DateTimeOffset MessageTime { get; set; }

        /// <summary>
        /// Gets or sets the message type.
        /// </summary>
        [DataMember(Name = "MessageType")]
        public MessageType MessageType { get; set; }

        /// <summary>
        /// Gets or sets the message source type.
        /// </summary>
        [DataMember(Name = "MessageSourceType")]
        public MessageSourceType MessageSourceType { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [DataMember(Name = "Message")]
        public string Message { get; set; }
    }
}