// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderRepository.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the FolderRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Logic.Implementation.Folder
{
    using System.Collections.Generic;
    using System.Linq;

    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Core.Contract.Interface.Folder;

    /// <summary>
    /// The folder repository.
    /// </summary>
    internal class FolderRepository : IFolderRepository
    {
        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly UnitOfWork unitOfWork;

        public FolderRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IFolderBusinessObject> List()
        {
            return this.unitOfWork.Context.Folders.AsEnumerable().Select(folder => new FolderBusinessObject(folder, this.unitOfWork));
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="folderId">
        /// The folder id.
        /// </param>
        /// <returns>
        /// The <see cref="IFolderBusinessObject"/>.
        /// </returns>
        public IFolderBusinessObject Get(long folderId)
        {
            var model = this.unitOfWork.Context.Folders.First(folder => folder.FolderId == folderId);

            return new FolderBusinessObject(model, this.unitOfWork);
        }
    }
}