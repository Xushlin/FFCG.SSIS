namespace FFCG.SSIS.Core.Contract.Interface.Operation
{
    using System;

    public interface IOperationBusinessObject
    {
        /// <summary>
        /// Gets the operation id.
        /// </summary>
        long OperationId { get; }

        /// <summary>
        /// Gets the operation type.
        /// </summary>
        OperationType OperationType { get; }

        /// <summary>
        /// Gets the created time.
        /// </summary>
        DateTimeOffset? CreatedTime { get; }

        /// <summary>
        /// Gets the object type.
        /// </summary>
        ObjectType? ObjectType { get; }

        /// <summary>
        /// Gets the object id.
        /// </summary>
        long? ObjectId { get; }

        /// <summary>
        /// Gets the object name.
        /// </summary>
        string ObjectName { get; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        OperationStatus Status { get; }

        /// <summary>
        /// Gets the start time.
        /// </summary>
        DateTimeOffset? StartTime { get; }

        /// <summary>
        /// Gets the end time.
        /// </summary>
        DateTimeOffset? EndTime { get; }

        /// <summary>
        /// Gets the caller sid.
        /// </summary>
        byte[] CallerSid { get; }

        /// <summary>
        /// Gets the caller name.
        /// </summary>
        string CallerName { get; }

        /// <summary>
        /// Gets the process id.
        /// </summary>
        int? ProcessId { get; }

        /// <summary>
        /// Gets the stopped by sid.
        /// </summary>
        byte[] StoppedBySid { get; }

        /// <summary>
        /// Gets the stopped by name.
        /// </summary>
        string StoppedByName { get; }

        /// <summary>
        /// Gets the server name.
        /// </summary>
        string ServerName { get; }

        /// <summary>
        /// Gets the machine name.
        /// </summary>
        string MachineName { get; }
    }
}