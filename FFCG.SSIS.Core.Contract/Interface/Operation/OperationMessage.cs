// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationMessage.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the OperationMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Operation
{
    using System;

    /// <summary>
    /// The operation message.
    /// </summary>
    public class OperationMessage
    {
        /// <summary>
        /// Gets or sets the message time.
        /// </summary>
        public DateTimeOffset MessageTime { get; set; }

        /// <summary>
        /// Gets or sets the message type.
        /// </summary>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// Gets or sets the message source type.
        /// </summary>
        public MessageSourceType MessageSourceType { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
    }
}