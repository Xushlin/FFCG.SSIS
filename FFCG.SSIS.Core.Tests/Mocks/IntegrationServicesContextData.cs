// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntegrationServicesContextData.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The integration services context data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Tests.Mocks
{
    using System.Collections.Generic;

    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Data.Interface;
    using FFCG.SSIS.Core.Data.Model;

    using OperationMessage = FFCG.SSIS.Core.Data.Model.OperationMessage;

    /// <summary>
    /// The integration services context data.
    /// </summary>
    public static class IntegrationServicesContextData
    {
        /// <summary>
        /// The package id 1.
        /// </summary>
        public const long PackageId1 = 1;

        /// <summary>
        /// The package id 2.
        /// </summary>
        public const long PackageId2 = 2;

        /// <summary>
        /// The package name 1.
        /// </summary>
        public const string PackageName1 = "PACKAGE_1";

        /// <summary>
        /// The package name 2.
        /// </summary>
        public const string PackageName2 = "PACKAGE_2";

        /// <summary>
        /// The project id 1.
        /// </summary>
        public const long ProjectId1 = 3;

        /// <summary>
        /// The project id 2.
        /// </summary>
        public const long ProjectId2 = 4;

        /// <summary>
        /// The project name 1.
        /// </summary>
        public const string ProjectName1 = "PROJECT_1";

        /// <summary>
        /// The package name 2.
        /// </summary>
        public const string ProjectName2 = "PROJECT_2";

        /// <summary>
        /// The folder id 1.
        /// </summary>
        public const long FolderId1 = 5;

        /// <summary>
        /// The folder id 2.
        /// </summary>
        public const long FolderId2 = 6;

        /// <summary>
        /// The folder name 1.
        /// </summary>
        public const string FolderName1 = "FOLDER_1";

        /// <summary>
        /// The folder name 2.
        /// </summary>
        public const string FolderName2 = "FOLDER_2";

        /// <summary>
        /// The operation id 1.
        /// </summary>
        public const long OperationId1 = 7;

        /// <summary>
        /// The operation id 2.
        /// </summary>
        public const long OperationId2 = 8;

        /// <summary>
        /// The operation id 3.
        /// </summary>
        public const long OperationId3 = 9;

        /// <summary>
        /// The operation message 1.
        /// </summary>
        public const string OperationMessage1 = "MSG1";

        /// <summary>
        /// The operation message id 1.
        /// </summary>
        public const long OperationMessageId1 = 10;

        /// <summary>
        /// The operation message 1.
        /// </summary>
        public const string OperationMessage2 = "MSG2";

        /// <summary>
        /// The operation message id 1.
        /// </summary>
        public const long OperationMessageId2 = 11;

        /// <summary>
        /// The operation message 1.
        /// </summary>
        public const string OperationMessage3 = "MSG3";

        /// <summary>
        /// The operation message id 1.
        /// </summary>
        public const long OperationMessageId3 = 12;

        /// <summary>
        /// The default seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public static void DefaultSeed(IIntegrationServicesContext context)
        {
            var package1 = new Package { PackageId = PackageId1, Name = PackageName1, ProjectId = ProjectId1 };
            var package2 = new Package { PackageId = PackageId2, Name = PackageName2, ProjectId = ProjectId2 };

            context.Packages.Add(package1);
            context.Packages.Add(package2);

            var project1 = new Project { ProjectId = ProjectId1, Name = ProjectName1, FolderId = FolderId1, Packages = new HashSet<Package> { package1 } };
            var project2 = new Project { ProjectId = ProjectId2, Name = ProjectName2, FolderId = FolderId2, Packages = new HashSet<Package> { package2 } };

            package1.Project = project1;
            package2.Project = project2;

            context.Projects.Add(project1);
            context.Projects.Add(project2);

            var folder1 = new Folder { FolderId = FolderId1, Name = FolderName1, Projects = new HashSet<Project> { project1 } };
            var folder2 = new Folder { FolderId = FolderId2, Name = FolderName2, Projects = new HashSet<Project> { project2 } };

            project1.Folder = folder1;
            project2.Folder = folder2;
            context.Folders.Add(folder1);
            context.Folders.Add(folder2);

            var operation1 = new Operation { OperationId = OperationId1, Status = (int)OperationStatus.Completed, ObjectType = (int)ObjectType.Project, ObjectId = ProjectId1 };
            var operation2 = new Operation { OperationId = OperationId2, Status = (int)OperationStatus.Completed, ObjectType = (int)ObjectType.Project, ObjectId = ProjectId2 };
            var operation3 = new Operation { OperationId = OperationId3, Status = (int)OperationStatus.Completed, ObjectType = (int)ObjectType.Project, ObjectId = ProjectId1 };

            context.Operations.Add(operation1);
            context.Operations.Add(operation2);
            context.Operations.Add(operation3);

            var operationMessage1 = new OperationMessage { Operation = operation1, OperationId = OperationId1, MessageType = (short)MessageType.Information, MessageSourceType = (short)MessageSourceType.PackageLevel, Message = OperationMessage1, OperationMessageId = OperationMessageId1 };
            var operationMessage2 = new OperationMessage { Operation = operation2, OperationId = OperationId2, MessageType = (short)MessageType.Information, MessageSourceType = (short)MessageSourceType.PackageLevel, Message = OperationMessage2, OperationMessageId = OperationMessageId2 };
            var operationMessage3 = new OperationMessage { Operation = operation3, OperationId = OperationId3, MessageType = (short)MessageType.Information, MessageSourceType = (short)MessageSourceType.PackageLevel, Message = OperationMessage3, OperationMessageId = OperationMessageId3 };

            context.OperationMessages.Add(operationMessage1);
            context.OperationMessages.Add(operationMessage2);
            context.OperationMessages.Add(operationMessage3);

            operation1.OperationMessages.Add(operationMessage1);
            operation2.OperationMessages.Add(operationMessage2);
            operation3.OperationMessages.Add(operationMessage3);

            var execution1 = new Execution { ExecutionId  = OperationId1, Status = (int)OperationStatus.Completed, ObjectType = (int)ObjectType.Project, ObjectId = ProjectId1, PackageName = PackageName1, ProjectName = ProjectName1, FolderName = FolderName1, Operation = operation1 };
            var execution2 = new Execution { ExecutionId = OperationId2, Status = (int)OperationStatus.Completed, ObjectType = (int)ObjectType.Project, ObjectId = ProjectId2, PackageName = PackageName2, ProjectName = ProjectName2, FolderName = FolderName2, Operation = operation2 };
            
            context.Executions.Add(execution1);
            context.Executions.Add(execution2);

            operation1.Execution = execution1;
            operation2.Execution = execution2;

            context.SaveChanges();
        }
    }
}