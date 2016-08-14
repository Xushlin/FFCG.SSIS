// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageBusinessObject.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the PackageBusinessObject type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Logic.Implementation.Package
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Contract.Interface.Package;
    using FFCG.SSIS.Core.Contract.Interface.Project;
    using FFCG.SSIS.Core.Data.Model;
    using FFCG.SSIS.Core.Logic.Implementation.Operation;
    using FFCG.SSIS.Core.Logic.Implementation.Project;

    /// <summary>
    /// The package business object.
    /// </summary>
    internal class PackageBusinessObject : IPackageBusinessObject
    {
        /// <summary>
        /// The model.
        /// </summary>
        private readonly Package model;

        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly UnitOfWork unitOfWork;

        public PackageBusinessObject(Package model, UnitOfWork unitOfWork)
        {
            this.model = model;
            this.unitOfWork = unitOfWork;
        }

        public long PackageId => this.model.PackageId;

        public string Name => this.model.Name;

        public Guid PackageGuid => this.model.PackageGuid;

        public string Description => this.model.Description;

        public int PackageFormatVersion => this.model.PackageFormatVersion;

        public int VersionMajor => this.model.VersionMajor;

        public int VersionMinor => this.model.VersionMinor;

        public int VersionBuild => this.model.VersionBuild;

        public string VersionComments => this.model.VersionComments;

        public Guid VersionGuid => this.model.VersionGuid;

        public bool EntryPoint => this.model.EntryPoint;

        public char ValidationStatus => this.model.ValidationStatus;

        public DateTimeOffset? LastValidationTime => this.model.LastValidationTime;

        public IProjectBusinessObject Project => new ProjectBusinessObject(this.model.Project, this.unitOfWork);

        public IEnumerable<IOperationBusinessObject> Operations
        {
            get
            {
                return this.unitOfWork.Context.Operations
                    .Where(op => op.ObjectType == (short)ObjectType.Package && op.ObjectId == this.model.PackageId)
                    .AsEnumerable()
                    .Select(op => new OperationBusinessObject(op, this.unitOfWork));
            }
        }

        public IOperationBusinessObject Execute(IEnumerable<PackageParameter> parameters)
        {
            var project = this.model.Project;
            var folder = project.Folder;

            var operationId = this.unitOfWork.Context.CreateExecution(this.model.Name, folder.Name, project.Name);

            foreach (var parameter in parameters)
            {
                this.unitOfWork.Context.SetExecutionParameterValue(operationId, (short)parameter.ObjectType, parameter.ParameterName, parameter.Value);
            }

            this.unitOfWork.Context.StartExecution(operationId);

            var operation = this.unitOfWork.Context.Operations.First(o => o.OperationId == operationId);
            return new OperationBusinessObject(operation, this.unitOfWork);
        }
    }
}