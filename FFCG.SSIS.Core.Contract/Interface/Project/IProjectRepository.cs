// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProjectRepository.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the IProjectRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Project
{
    using System.Collections.Generic;

    /// <summary>
    /// The ProjectRepository interface.
    /// </summary>
    public interface IProjectRepository
    {
        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IProjectBusinessObject> List();

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="folderId">
        /// The folder id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IProjectBusinessObject> List(long folderId);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="projectId">
        /// The project id.
        /// </param>
        /// <returns>
        /// The <see cref="IProjectBusinessObject"/>.
        /// </returns>
        IProjectBusinessObject Get(long projectId);
    }
}