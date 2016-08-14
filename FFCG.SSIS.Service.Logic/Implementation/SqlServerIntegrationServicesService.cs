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
    using System.Linq;

    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Core.Contract.Interface.Folder;
    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Contract.Interface.Package;
    using FFCG.SSIS.Core.Contract.Interface.Project;
    using FFCG.SSIS.Service.Contract.Interface;
    using FFCG.SSIS.Service.Contract.Model;

    /// <summary>
    /// The SQL server integration services serverIntegrationServicesService.
    /// </summary>
    public class SqlServerIntegrationServicesService : ISqlServerIntegrationServicesService
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
            var package = this.unitOfWork.Packages.Get(packageName, projectName, folderName);

            return ToServiceModel(package.Execute(packageParameters.Select(ToBusinessLogic)));
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
            var package = this.unitOfWork.Packages.Get(packageName, projectName, folderName);
            
            return ToServiceModel(package);
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
            var project = this.unitOfWork.Projects.Get(projectName, folderName);
            return new PackageDescriptions(project.Packages.Select(ToServiceModel));
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
            return new OperationDescriptions(this.unitOfWork.Packages.Get(packageName, projectName, folderName).Operations.Select(ToServiceModel));
        }

        /// <summary>
        /// The get operation.
        /// </summary>
        /// <param name="operationId">
        /// The operation id.
        /// </param>
        /// <returns>
        /// The <see cref="OperationDescriptions"/>.
        /// </returns>
        public OperationDescription GetOperation(long operationId)
        {
            return ToServiceModel(this.unitOfWork.Operations.Get(operationId));
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
            var operation = this.unitOfWork.Operations.Get(operationId);

            return new OperationMessages(operation.Messages.Select(ToServiceModel));


        }

        /// <summary>
        /// The list folders.
        /// </summary>
        /// <returns>
        /// The <see cref="FolderDescriptions"/>.
        /// </returns>
        public FolderDescriptions ListFolders()
        {
            return new FolderDescriptions(this.unitOfWork.Folders.List().Select(ToServiceModel));
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
            return ToServiceModel(this.unitOfWork.Folders.Get(folder));
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
            return new ProjectDescriptions(this.unitOfWork.Projects.List(folder).Select(ToServiceModel));
        }

        /// <summary>
        /// The get project.
        /// </summary>
        /// <param name="projectName">
        /// The project Name.
        /// </param>
        /// <param name="folderName">
        /// The folder Name.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectDescription"/>.
        /// </returns>
        public ProjectDescription GetProject(string projectName, string folderName)
        {
            var project = this.unitOfWork.Projects.Get(projectName, folderName);
            return ToServiceModel(project);
        }

        /// <summary>
        /// The to serverIntegrationServicesService model.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        /// <returns>
        /// The <see cref="PackageDescription"/>.
        /// </returns>
        private static PackageDescription ToServiceModel(IPackageBusinessObject package)
        {
            var project = package.Project;
            var folder = project.Folder;

            return new PackageDescription
            {
                PackageName = package.Name,
                ValidationStatus = package.ValidationStatus,
                VersionGuid = package.VersionGuid,
                LastValidationTime = package.LastValidationTime,
                PackageGuid = package.PackageGuid,
                PackageFormatVersion = package.PackageFormatVersion,
                VersionMajor = package.VersionMajor,
                EntryPoint = package.EntryPoint,
                VersionBuild = package.VersionBuild,
                VersionMinor = package.VersionMinor,
                Description = package.Description,
                VersionComments = package.VersionComments,
                FolderName = folder.Name,
                ProjectName = project.Name
            };
        }

        /// <summary>
        /// The to serverIntegrationServicesService model.
        /// </summary>
        /// <param name="operation">
        /// The operation.
        /// </param>
        /// <returns>
        /// The <see cref="OperationDescription"/>.
        /// </returns>
        private static OperationDescription ToServiceModel(IOperationBusinessObject operation)
        {
            return new OperationDescription
            {
                ObjectType = operation.ObjectType.HasValue ? (FFCG.SSIS.Service.Contract.Model.ObjectType)operation.ObjectType.Value : default(FFCG.SSIS.Service.Contract.Model.ObjectType?),
                OperationId = operation.OperationId,
                OperationType = (FFCG.SSIS.Service.Contract.Model.OperationType)operation.OperationType,
                Status = (FFCG.SSIS.Service.Contract.Model.OperationStatus)operation.Status,
                CreatedTime = operation.CreatedTime,
                EndTime = operation.EndTime,
                StartTime = operation.StartTime
            };
        }

        /// <summary>
        /// The to serverIntegrationServicesService model.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="OperationMessage"/>.
        /// </returns>
        private static FFCG.SSIS.Service.Contract.Model.OperationMessage ToServiceModel(FFCG.SSIS.Core.Contract.Interface.Operation.OperationMessage message)
        {
            return new FFCG.SSIS.Service.Contract.Model.OperationMessage
            {
                MessageType = (FFCG.SSIS.Service.Contract.Model.MessageType)message.MessageType,
                MessageSourceType = (FFCG.SSIS.Service.Contract.Model.MessageSourceType)message.MessageSourceType,
                Message = message.Message,
                MessageTime = message.MessageTime
            };
        }

        /// <summary>
        /// The to serverIntegrationServicesService model.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectDescription"/>.
        /// </returns>
        private static ProjectDescription ToServiceModel(IProjectBusinessObject project)
        {
            return new ProjectDescription
            {
                Name = project.Name,
                Description = project.Description,
                CreatedTime = project.CreatedTime,
                FolderName = project.Folder.Name
            };
        }

        /// <summary>
        /// The to serverIntegrationServicesService model.
        /// </summary>
        /// <param name="folder">
        /// The folder.
        /// </param>
        /// <returns>
        /// The <see cref="FolderDescription"/>.
        /// </returns>
        private static FolderDescription ToServiceModel(IFolderBusinessObject folder)
        {
            return new FolderDescription
            {
                Name = folder.Name,
                CreatedTime = folder.CreatedTime,
                Description = folder.Description
            };
        }

        /// <summary>
        /// The to business logic.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// The <see cref="PackageParameter"/>.
        /// </returns>
        private static FFCG.SSIS.Core.Contract.Interface.Package.PackageParameter ToBusinessLogic(FFCG.SSIS.Service.Contract.Model.PackageParameter parameter)
        {
            return new FFCG.SSIS.Core.Contract.Interface.Package.PackageParameter
            {
                ObjectType = (FFCG.SSIS.Core.Contract.Interface.Operation.ObjectType)parameter.ObjectType,
                Value = parameter.Value,
                ParameterName = parameter.ParameterName
            };
        }
    }
}