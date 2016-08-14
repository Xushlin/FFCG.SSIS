// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationStatus.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the OperationStatus type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Operation
{
    /// <summary>
    /// The operation status.
    /// </summary>
    public enum OperationStatus
    {
        /// <summary>
        /// The created.
        /// </summary>
        Created = 1,

        /// <summary>
        /// The running.
        /// </summary>
        Running = 2,

        /// <summary>
        /// The canceled.
        /// </summary>
        Canceled = 3,

        /// <summary>
        /// The failed.
        /// </summary>
        Failed = 4,

        /// <summary>
        /// The pending.
        /// </summary>
        Pending = 5,

        /// <summary>
        /// The ended unexpectedly.
        /// </summary>
        EndedUnexpectedly = 6,

        /// <summary>
        /// The succeeded.
        /// </summary>
        Succeeded = 7,

        /// <summary>
        /// The stopping.
        /// </summary>
        Stopping = 8,

        /// <summary>
        /// The completed.
        /// </summary>
        Completed = 9
    }
}