// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageSourceType.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the MessageSourceType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The message source type.
    /// </summary>
    [DataContract(Name = "MessageSourceType", Namespace = Constants.Namespace)]
    public enum MessageSourceType
    {
        /// <summary>
        /// The entry API.
        /// </summary>
        [EnumMember(Value = "EntryApi")]
        EntryApi = 10,

        /// <summary>
        /// The external process.
        /// </summary>
        [EnumMember(Value = "ExternalProcess")]
        ExternalProcess = 20,

        /// <summary>
        /// The package level.
        /// </summary>
        [EnumMember(Value = "PackageLevel")]
        PackageLevel = 30,

        /// <summary>
        /// The control flow task.
        /// </summary>
        [EnumMember(Value = "ControlFlowTask")]
        ControlFlowTask = 40,

        /// <summary>
        /// The control flow container.
        /// </summary>
        [EnumMember(Value = "ControlFlowContainer")]
        ControlFlowContainer = 50,

        /// <summary>
        /// The data flow task.
        /// </summary>
        [EnumMember(Value = "DataFlowTask")]
        DataFlowTask = 60
    }
}