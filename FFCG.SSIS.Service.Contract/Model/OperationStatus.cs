// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationStatus.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the OperationStatus type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The operation status.
    /// </summary>
    [DataContract(Name = "OperationStatus", Namespace = Constants.Namespace)]
    public enum OperationStatus
    {
        /// <summary>
        /// The created.
        /// </summary>
        [EnumMember(Value = "Created")]
        Created = 1,

        /// <summary>
        /// The running.
        /// </summary>
        [EnumMember(Value = "Running")]
        Running = 2,

        /// <summary>
        /// The canceled.
        /// </summary>
        [EnumMember(Value = "Canceled")]
        Canceled = 3,

        /// <summary>
        /// The failed.
        /// </summary>
        [EnumMember(Value = "Failed")]
        Failed = 4,

        /// <summary>
        /// The pending.
        /// </summary>
        [EnumMember(Value = "Pending")]
        Pending = 5,

        /// <summary>
        /// The ended unexpectedly.
        /// </summary>
        [EnumMember(Value = "EndedUnexpectedly")]
        EndedUnexpectedly = 6,

        /// <summary>
        /// The succeeded.
        /// </summary>
        [EnumMember(Value = "Succeeded")]
        Succeeded = 7,

        /// <summary>
        /// The stopping.
        /// </summary>
        [EnumMember(Value = "Stopping")]
        Stopping = 8,

        /// <summary>
        /// The completed.
        /// </summary>
        [EnumMember(Value = "Completed")]
        Completed = 9
    }
}