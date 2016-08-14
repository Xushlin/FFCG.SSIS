// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISqlServerIntegrationServicesService.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the ISqlServerIntegrationServicesService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Interface
{
    using System.Diagnostics.Eventing.Reader;
    using System.ServiceModel;

    using FFCG.SSIS.Service.Contract.Model;

    /// <summary>
    /// The PackageService interface.
    /// </summary>
    [ServiceContract(Name = "SqlServiceIntegrationServicesService", Namespace = Constants.Namespace)]
    public interface ISqlServerIntegrationServicesService
    {
        /// <summary>
        /// The execute.
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
        /// The PackageParameters.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        [OperationContract(Name = "ExecutePackage")]
        OperationDescription ExecutePackage(string packageName, string projectName, string folderName, PackageParameters packageParameters);

        /// <summary>
        /// The get.
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
        [OperationContract(Name = "GetPackage")]
        PackageDescription GetPackage(string packageName, string projectName, string folderName);

        /// <summary>
        /// The list.
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
        [OperationContract(Name = "ListPackages")]
        PackageDescriptions ListPackages(string projectName, string folderName);

        /// <summary>
        /// The list.
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
        [OperationContract(Name = "ListOperations")]
        OperationDescriptions ListOperations(string packageName, string projectName, string folderName);

        /// <summary>
        /// The get operation.
        /// </summary>
        /// <param name="operationId">
        /// The operation id.
        /// </param>
        /// <returns>
        /// The <see cref="OperationDescriptions"/>.
        /// </returns>
        [OperationContract(Name = "GetOperation")]
        OperationDescription GetOperation(long operationId);

        /// <summary>
        /// The list operation messages.
        /// </summary>
        /// <param name="operationId">
        /// The operation id.
        /// </param>
        /// <returns>
        /// The <see cref="OperationMessages"/>.
        /// </returns>
        [OperationContract(Name = "ListOperationMessages")]
        OperationMessages ListOperationMessages(long operationId);

        /// <summary>
        /// The list folders.
        /// </summary>
        /// <returns>
        /// The <see cref="FolderDescriptions"/>.
        /// </returns>
        [OperationContract(Name = "ListFolders")]
        FolderDescriptions ListFolders();

        /// <summary>
        /// The get folder.
        /// </summary>
        /// <param name="folder">
        /// The folder.
        /// </param>
        /// <returns>
        /// The <see cref="FolderDescription"/>.
        /// </returns>
        [OperationContract(Name = "GetFolder")]
        FolderDescription GetFolder(string folder);

        /// <summary>
        /// The list projects.
        /// </summary>
        /// <param name="folder">
        /// The folder.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectDescriptions"/>.
        /// </returns>
        [OperationContract(Name = "ListProjects")]
        ProjectDescriptions ListProjects(string folder);

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
        [OperationContract(Name = "GetProject")]
        ProjectDescription GetProject(string project, string folder);
    }
}