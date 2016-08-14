// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlServerIntegrationServicesService.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the SqlServerIntegrationServicesService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Logic.Implementation
{
    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Service.Contract.Interface;
    using FFCG.SSIS.Service.Contract.Model;

    /// <summary>
    /// The SQL server integration services service.
    /// </summary>
    public class SqlServerIntegrationServicesService : ISqlServiceIntegrationServicesService
    {
        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        public SqlServerIntegrationServicesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// The execute package.
        /// </summary>
        /// <param name="packageName">
        /// The package name.
        /// </param>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <param name="packageParameters">
        /// The package parameters.
        /// </param>
        /// <returns>
        /// The <see cref="OperationDescription"/>.
        /// </returns>
        public OperationDescription ExecutePackage(string packageName, string projectName, string folderName, PackageParameters packageParameters)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The get package.
        /// </summary>
        /// <param name="packageName">
        /// The package name.
        /// </param>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <returns>
        /// The <see cref="PackageDescription"/>.
        /// </returns>
        public PackageDescription GetPackage(string packageName, string projectName, string folderName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The list packages.
        /// </summary>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <returns>
        /// The <see cref="PackageDescriptions"/>.
        /// </returns>
        public PackageDescriptions ListPackages(string projectName, string folderName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The list operations.
        /// </summary>
        /// <param name="packageName">
        /// The package name.
        /// </param>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <returns>
        /// The <see cref="OperationDescriptions"/>.
        /// </returns>
        public OperationDescriptions ListOperations(string packageName, string projectName, string folderName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The list operation messages.
        /// </summary>
        /// <param name="operationId">
        /// The operation id.
        /// </param>
        /// <returns>
        /// The <see cref="OperationMessages"/>.
        /// </returns>
        public OperationMessages ListOperationMessages(long operationId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The list folders.
        /// </summary>
        /// <returns>
        /// The <see cref="FolderDescriptions"/>.
        /// </returns>
        public FolderDescriptions ListFolders()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The get folder.
        /// </summary>
        /// <param name="folder">
        /// The folder.
        /// </param>
        /// <returns>
        /// The <see cref="FolderDescription"/>.
        /// </returns>
        public FolderDescription GetFolder(string folder)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The list projects.
        /// </summary>
        /// <param name="folder">
        /// The folder.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectDescriptions"/>.
        /// </returns>
        public ProjectDescriptions ListProjects(string folder)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The get project.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <param name="folder">
        /// The folder.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectDescription"/>.
        /// </returns>
        public ProjectDescription GetProject(string project, string folder)
        {
            throw new System.NotImplementedException();
        }
    }
}