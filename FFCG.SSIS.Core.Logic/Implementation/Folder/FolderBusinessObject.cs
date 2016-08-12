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
    using FFCG.SSIS.Core.Contract.Interface.Folder;
    using FFCG.SSIS.Core.Data.Model;

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
    }
}