// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderBusinessObject.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the FolderBusinessObject type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Logic.Implementation.Folder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FFCG.SSIS.Core.Contract.Interface.Folder;
    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Contract.Interface.Project;
    using FFCG.SSIS.Core.Data.Model;
    using FFCG.SSIS.Core.Logic.Implementation.Operation;
    using FFCG.SSIS.Core.Logic.Implementation.Project;

    /// <summary>
    /// The folder business object.
    /// </summary>
    internal class FolderBusinessObject : IFolderBusinessObject
    {
        /// <summary>
        /// The model.
        /// </summary>
        private readonly Folder model;

        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly UnitOfWork unitOfWork;

        public FolderBusinessObject(Folder model, UnitOfWork unitOfWork)
        {
            this.model = model;
            this.unitOfWork = unitOfWork;
        }

        public long FolderId => this.model.FolderId;

        public string Name => this.model.Name;

        public string Description => this.model.Description;

        public byte[] CreatedBySid => this.model.CreatedBySid;

        public string CreatedByName => this.model.CreatedByName;

        public DateTimeOffset CreatedTime => this.model.CreatedTime;

        public IEnumerable<IProjectBusinessObject> Projects => this.model.Projects.AsEnumerable().Select(proj => new ProjectBusinessObject(proj, this.unitOfWork));

        public IEnumerable<IOperationBusinessObject> Operations => this.unitOfWork.Context.Operations.Where(op => op.ObjectType == (short)ObjectType.Folder && op.ObjectId == this.FolderId).AsEnumerable().Select(op => new OperationBusinessObject(op, this.unitOfWork));
    }
}