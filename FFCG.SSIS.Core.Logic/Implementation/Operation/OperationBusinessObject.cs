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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using FFCG.SSIS.Core.Contract.Interface.Folder;
    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Contract.Interface.Package;
    using FFCG.SSIS.Core.Contract.Interface.Project;
    using FFCG.SSIS.Core.Data.Model;
    using FFCG.SSIS.Core.Logic.Implementation.Folder;
    using FFCG.SSIS.Core.Logic.Implementation.Package;
    using FFCG.SSIS.Core.Logic.Implementation.Project;

    using OperationMessage = FFCG.SSIS.Core.Contract.Interface.Operation.OperationMessage;

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

        public IFolderBusinessObject Folder
        {
            get
            {
                switch (this.ObjectType)
                {
                    case Contract.Interface.Operation.ObjectType.Folder:
                        if (this.model.ObjectId.HasValue)
                        {
                            var folder = this.unitOfWork.Context.Folders.First(f => f.FolderId == this.model.ObjectId);
                            return new FolderBusinessObject(folder, this.unitOfWork);
                        }

                        return default(IFolderBusinessObject);
                    default:
                        return default(IFolderBusinessObject);
                }
            }
        }

        public IProjectBusinessObject Project
        {
            get
            {
                switch (this.ObjectType)
                {
                    case Contract.Interface.Operation.ObjectType.Project:
                        if (this.model.ObjectId.HasValue)
                        {
                            var project = this.unitOfWork.Context.Projects.First(p => p.ProjectId == this.model.ObjectId);
                            return new ProjectBusinessObject(project, this.unitOfWork);
                        }

                        return default(IProjectBusinessObject);
                    default:
                        return default(IProjectBusinessObject);
                }
            }
        }

        public IPackageBusinessObject Package
        {
            get
            {
                switch (this.ObjectType)
                {
                    case Contract.Interface.Operation.ObjectType.Package:
                        if (this.model.ObjectId.HasValue)
                        {
                            var package = this.unitOfWork.Context.Packages.First(p => p.PackageId == this.model.ObjectId);
                            return new PackageBusinessObject(package, this.unitOfWork);
                        }

                        return default(IPackageBusinessObject);
                    default:
                        return default(IPackageBusinessObject);
                }
            }
        }

        public IEnumerable<OperationMessage> Messages
            =>
                this.model.OperationMessages.AsEnumerable().Select(
                    opm =>
                    new OperationMessage
                        {
                            MessageType = (MessageType)opm.MessageType,
                            MessageSourceType = (MessageSourceType)opm.MessageSourceType,
                            Message = opm.Message,
                            MessageTime = opm.MessageTime
                        });
    }
}