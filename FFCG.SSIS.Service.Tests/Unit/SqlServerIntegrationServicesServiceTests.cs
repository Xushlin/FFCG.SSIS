// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlServerIntegrationServicesServiceTests.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the SqlServerIntegrationServicesServiceTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Tests.Unit
{
    using System.Linq;

    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Core.Logic.Implementation;
    using FFCG.SSIS.Core.Tests.Mocks;
    using FFCG.SSIS.Service.Contract.Interface;
    using FFCG.SSIS.Service.Contract.Model;
    using FFCG.SSIS.Service.Logic.Implementation;
    using FFCG.SSIS.Tools.Logic.Implementation;

    using Moq;

    using NUnit.Framework;

    /// <summary>
    /// The SQL server integration services serverIntegrationServicesService tests.
    /// </summary>
    [TestFixture]
    public class SqlServerIntegrationServicesServiceTests
    {
        /// <summary>
        /// The mock unit of work.
        /// </summary>
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// The serverIntegrationServicesService.
        /// </summary>
        private ISqlServerIntegrationServicesService service;

        /// <summary>
        /// The mock context.
        /// </summary>
        private IntegrationServicesContextMock mockContext;

        /// <summary>
        /// The parameters.
        /// </summary>
        private PackageParameters parameters;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.mockContext = new IntegrationServicesContextMock();
            this.unitOfWork = new UnitOfWork(this.mockContext.Object, new ObjectProvider());
            this.service = new SqlServerIntegrationServicesService(this.unitOfWork);

            this.parameters =
                new PackageParameters(
                    new[]
                        {
                            new PackageParameter
                                {
                                    ObjectType = Data.ParameterObjectType1,
                                    Value = Data.ParameterValue1,
                                    ParameterName = Data.ParameterName1
                                },
                            new PackageParameter
                                {
                                    ObjectType = Data.ParameterObjectType2,
                                    Value = Data.ParameterValue2,
                                    ParameterName = Data.ParameterName2
                                }
                        });

            this.mockContext.Setup(ctx => ctx.CreateExecution(IntegrationServicesContextData.PackageName1, IntegrationServicesContextData.FolderName1, IntegrationServicesContextData.ProjectName1, null, false)).Returns(IntegrationServicesContextData.OperationId1);
        }

        /// <summary>
        /// The should be able to fetch a package.
        /// </summary>
        [Test]
        public void ShouldBeAbleToFetchAPackage()
        {
            var package = this.service.GetPackage(IntegrationServicesContextData.PackageName1, IntegrationServicesContextData.ProjectName1, IntegrationServicesContextData.FolderName1);

            Assert.AreEqual(IntegrationServicesContextData.PackageName1, package.PackageName, "PackageName");
        }

        /// <summary>
        /// The should be able to list packages.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListPackages()
        {
            var packages = this.service.ListPackages(IntegrationServicesContextData.ProjectName1, IntegrationServicesContextData.FolderName1);

            Assert.AreEqual(this.mockContext.Project1.Packages.Count, packages.Count, "Number of packages");
        }

        /// <summary>
        /// The should be able to execute a package.
        /// </summary>
        [Test]
        public void ShouldBeAbleToExecuteAPackage()
        {
            var operation = this.service.ExecutePackage(IntegrationServicesContextData.PackageName1, IntegrationServicesContextData.ProjectName1, IntegrationServicesContextData.FolderName1, this.parameters);

            Assert.IsNotNull(operation, "operation != null");
            
            this.mockContext.Verify(ctx => ctx.CreateExecution(IntegrationServicesContextData.PackageName1, IntegrationServicesContextData.FolderName1, IntegrationServicesContextData.ProjectName1, null, false), Times.Once);
            this.mockContext.Verify(ctx => ctx.SetExecutionParameterValue(IntegrationServicesContextData.OperationId1, (short)Data.ParameterObjectType1, Data.ParameterName1, Data.ParameterValue1), Times.Once);
            this.mockContext.Verify(ctx => ctx.SetExecutionParameterValue(IntegrationServicesContextData.OperationId1, (short)Data.ParameterObjectType2, Data.ParameterName2, Data.ParameterValue2), Times.Once);
            this.mockContext.Verify(ctx => ctx.StartExecution(IntegrationServicesContextData.OperationId1), Times.Once);
        }
        
        /// <summary>
        /// The should be able to list operations.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListOperations()
        {
            var operations = this.service.ListOperations(IntegrationServicesContextData.PackageName1, IntegrationServicesContextData.ProjectName1, IntegrationServicesContextData.FolderName1);
            
            Assert.AreEqual(1, operations.Count, "Count");
        }

        /// <summary>
        /// The should be able to list folders.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListFolders()
        {
            var folders = this.service.ListFolders();

            Assert.AreEqual(this.mockContext.FolderSet.Count(), folders.Count, "Number of folders");
        }

        /// <summary>
        /// The should be able to get a folder by name.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetAFolderByName()
        {
            var folder = this.service.GetFolder(IntegrationServicesContextData.FolderName1);

            Assert.IsNotNull(folder);
        }

        /// <summary>
        /// The should be able to list operation messages.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListOperationMessages()
        {
            var messages = this.service.ListOperationMessages(IntegrationServicesContextData.OperationId1);

            Assert.AreEqual(this.mockContext.Operation1.OperationMessages.Count, messages.Count, "Number of messages.");
        }

        /// <summary>
        /// The should be able to list projects.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListProjects()
        {
            var projects = this.service.ListProjects(IntegrationServicesContextData.FolderName1);

            Assert.AreEqual(this.mockContext.Folder1.Projects.Count, projects.Count, "Number of projects");
        }

        /// <summary>
        /// The should be able to get project by name.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetProjectByName()
        {
            var project = this.service.GetProject(IntegrationServicesContextData.ProjectName1, IntegrationServicesContextData.FolderName1);

            Assert.IsNotNull(project, "project != null");
        }

        /// <summary>
        /// The should be able to get an operation by name.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetAnOperationByName()
        {
            var operation = this.service.GetOperation(IntegrationServicesContextData.OperationId1);

            Assert.IsNotNull(operation, "operation != null");
        }

        /// <summary>
        /// The data.
        /// </summary>
        private static class Data
        {
            /// <summary>
            /// The parameter name 1.
            /// </summary>
            public const string ParameterName1 = "PARAM1";

            /// <summary>
            /// The parameter value 1.
            /// </summary>
            public const string ParameterValue1 = "99";

            /// <summary>
            /// The parameter object type 1.
            /// </summary>
            public const ObjectType ParameterObjectType1 = ObjectType.Package;

            /// <summary>
            /// The parameter name 2.
            /// </summary>
            public const string ParameterName2 = "PARAM2";

            /// <summary>
            /// The parameter value 2.
            /// </summary>
            public const string ParameterValue2 = "77";

            /// <summary>
            /// The parameter object type 2.
            /// </summary>
            public const ObjectType ParameterObjectType2 = ObjectType.Project;
        }
    }
}