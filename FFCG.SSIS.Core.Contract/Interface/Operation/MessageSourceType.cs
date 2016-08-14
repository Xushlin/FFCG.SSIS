// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageSourceType.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the MessageSourceType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Operation
{
    /// <summary>
    /// The message source type.
    /// </summary>
    public enum MessageSourceType
    {
        /// <summary>
        /// The entry API.
        /// </summary>
        EntryApi = 10,

        /// <summary>
        /// The external process.
        /// </summary>
        ExternalProcess = 20,

        /// <summary>
        /// The package level.
        /// </summary>
        PackageLevel = 30,

        /// <summary>
        /// The control flow task.
        /// </summary>
        ControlFlowTask = 40,

        /// <summary>
        /// The control flow container.
        /// </summary>
        ControlFlowContainer = 50,

        /// <summary>
        /// The data flow task.
        /// </summary>
        DataFlowTask = 60
    }
}