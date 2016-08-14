// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectRepository.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the ProjectRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Logic.Implementation.Project
{
    using System.Collections.Generic;
    using System.Linq;

    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Core.Contract.Interface.Project;

    /// <summary>
    /// The project repository.
    /// </summary>
    public class ProjectRepository : IProjectRepository
    {
        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly UnitOfWork unitOfWork;

        public ProjectRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IProjectBusinessObject> List()
        {
            return this.unitOfWork.Context.Projects.AsEnumerable().Select(prj => new ProjectBusinessObject(prj, this.unitOfWork));
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="folderId">
        /// The folder id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IProjectBusinessObject> List(long folderId)
        {
            return this.unitOfWork.Context.Projects.Where(proj => proj.FolderId == folderId).AsEnumerable().Select(proj => new ProjectBusinessObject(proj, this.unitOfWork));
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IProjectBusinessObject> List(string folderName)
        {
            var folder = this.unitOfWork.Context.Folders.First(f => f.Name == folderName);
            return folder.Projects.AsEnumerable().Select(proj => new ProjectBusinessObject(proj, this.unitOfWork));
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="projectId">
        /// The project id.
        /// </param>
        /// <returns>
        /// The <see cref="IProjectBusinessObject"/>.
        /// </returns>
        public IProjectBusinessObject Get(long projectId)
        {
            var project = this.unitOfWork.Context.Projects.First(proj => proj.ProjectId == projectId);

            return new ProjectBusinessObject(project, this.unitOfWork);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <returns>
        /// The <see cref="IProjectBusinessObject"/>.
        /// </returns>
        public IProjectBusinessObject Get(string projectName, string folderName)
        {
            var project = this.unitOfWork.Context.Projects.First(proj => proj.Name == projectName && proj.Folder.Name == folderName);

            return new ProjectBusinessObject(project, this.unitOfWork);
        }
    }
}