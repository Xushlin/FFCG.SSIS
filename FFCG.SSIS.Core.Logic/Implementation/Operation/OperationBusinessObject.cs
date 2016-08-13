// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationBusinessObject.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the OperationBusinessObject type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Logic.Implementation.Operation
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Data.Model;

    /// <summary>
    /// The operation business object.
    /// </summary>
    internal class OperationBusinessObject : IOperationBusinessObject
    {
        /// <summary>
        /// The model.
        /// </summary>
        private readonly Operation model;

        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly UnitOfWork unitOfWork;

        public OperationBusinessObject(Operation model, UnitOfWork unitOfWork)
        {
            this.model = model;
            this.unitOfWork = unitOfWork;
        }

        public long OperationId => this.model.OperationId;

        public OperationType OperationType => (OperationType)this.model.OperationType;

        public DateTimeOffset? CreatedTime => this.model.CreatedTime;

        public ObjectType? ObjectType => (ObjectType?)this.model.ObjectType;

        public long? ObjectId => this.model.OperationId;

        public string ObjectName => this.model.ObjectName;

        public OperationStatus Status => (OperationStatus)this.model.Status;

        public DateTimeOffset? StartTime => this.model.StartTime;

        public DateTimeOffset? EndTime => this.model.EndTime;

        public byte[] CallerSid => this.model.CallerSid;

        public string CallerName => this.model.CallerName;

        public int? ProcessId => this.model.ProcessId;

        public byte[] StoppedBySid => this.model.StoppedBySid;

        public string StoppedByName => this.model.StoppedByName;

        public string ServerName => this.model.ServerName;

        public string MachineName => this.model.MachineName;
    }
}