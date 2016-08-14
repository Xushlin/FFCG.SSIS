// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFolderRepository.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The FolderRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Folder
{
    using System.Collections.Generic;

    using FFCG.SSIS.Core.Data.Model;

    /// <summary>
    /// The FolderRepository interface.
    /// </summary>
    public interface IFolderRepository
    {
        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IFolderBusinessObject> List();

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="folderId">
        /// The folder id.
        /// </param>
        /// <returns>
        /// The <see cref="IFolderBusinessObject"/>.
        /// </returns>
        IFolderBusinessObject Get(long folderId);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <returns>
        /// The <see cref="IFolderBusinessObject"/>.
        /// </returns>
        IFolderBusinessObject Get(string folderName);
    }
}