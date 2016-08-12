// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectBusinessObject.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The project business object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Logic.Implementation.Project
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FFCG.SSIS.Core.Contract.Interface.Folder;
    using FFCG.SSIS.Core.Contract.Interface.Package;
    using FFCG.SSIS.Core.Contract.Interface.Project;
    using FFCG.SSIS.Core.Data.Model;
    using FFCG.SSIS.Core.Logic.Implementation.Folder;
    using FFCG.SSIS.Core.Logic.Implementation.Package;

    /// <summary>
    /// The project business object.
    /// </summary>
    internal class ProjectBusinessObject : IProjectBusinessObject
    {
        /// <summary>
        /// The model.
        /// </summary>
        private readonly Project model;

        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly UnitOfWork unitOfWork;

        public ProjectBusinessObject(Project model, UnitOfWork unitOfWork)
        {
            this.model = model;
            this.unitOfWork = unitOfWork;
        }

        public long ProjectId => this.model.ProjectId;

        public long FolderId => this.model.FolderId;

        public string Name => this.model.Name;

        public string Description => this.model.Description;

        public int? ProjectFormatVersion => this.model.ProjectFormatVersion;

        public byte[] DeployedBySid => this.model.DeployedBySid;

        public string DeployedByName => this.model.DeployedByName;

        public DateTimeOffset LastDeployedTime => this.model.LastDeployedTime;

        public DateTimeOffset CreatedTime => this.model.CreatedTime;

        public long ObjectVersion => this.model.ObjectVersion;

        public char ValidationStatus => this.model.ValidationStatus;

        public DateTimeOffset? LastValidationTime => this.model.LastValidationTime;

        public IFolderBusinessObject Folder => new FolderBusinessObject(this.model.Folder, this.unitOfWork);

        public IEnumerable<IPackageBusinessObject> Packages => this.model.Packages.AsEnumerable().Select(pkg => new PackageBusinessObject(pkg, this.unitOfWork));
    }
}