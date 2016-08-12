// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntegrationServicesContextTests.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the IntegrationServicesContextTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Tests.Integration
{
    using System;
    using System.Linq;

    using FFCG.SSIS.Core.Data.Implementation;
    using FFCG.SSIS.Core.Data.Interface;

    using NUnit.Framework;

    /// <summary>
    /// The integration services context tests.
    /// </summary>
    [TestFixture]
    [Ignore("Integration tests, requires connection to working SSIS environment and database.")]
    public class IntegrationServicesContextTests
    {
        /// <summary>
        /// The context.
        /// </summary>
        private IIntegrationServicesContext context;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.context = new IntegrationServicesContext();
        }

        /// <summary>
        /// The tear down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.context.Dispose();
        }

        /// <summary>
        /// The should be able to find an operation.
        /// </summary>
        [Test]
        public void ShouldBeAbleToFindAnOperation()
        {
            var operation = this.context.Operations.FirstOrDefault();

            Assert.IsNotNull(operation, "operation != null");
        }

        /// <summary>
        /// The should be able to find a folder.
        /// </summary>
        [Test]
        public void ShouldBeAbleToFindAFolder()
        {
            var folder = this.context.Folders.FirstOrDefault();

            Assert.IsNotNull(folder, "folder != null");
        }

        /// <summary>
        /// The should be able to find a project.
        /// </summary>
        [Test]
        public void ShouldBeAbleToFindAProject()
        {
            var project = this.context.Projects.FirstOrDefault();

            Assert.IsNotNull(project, "project != null");
        }

        /// <summary>
        /// The should be able to get folder.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetFolderFromProject()
        {
            var project = this.context.Projects.First();
            var folder = project.Folder;

            Assert.IsNotNull(folder, "folder != null");
        }

        /// <summary>
        /// The should be able to access projects from a folder.
        /// </summary>
        [Test]
        public void ShouldBeAbleToAccessProjectsFromAFolder()
        {
            var folder = this.context.Folders.First();
            var projects = folder.Projects;

            Assert.IsTrue(projects.Any(), "projects.Any()");
        }

        /// <summary>
        /// The should be able to fetch a package.
        /// </summary>
        [Test]
        public void ShouldBeAbleToFetchAPackage()
        {
            var package = this.context.Packages.FirstOrDefault();

            Assert.IsNotNull(package, "package != null");
        }

        /// <summary>
        /// The should be able to access project from package.
        /// </summary>
        [Test]
        public void ShouldBeAbleToAccessProjectFromPackage()
        {
            var package = this.context.Packages.First();
            var project = package.Project;

            Assert.IsNotNull(project, "project != null");
        }

        /// <summary>
        /// The should be able to list packages from project.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListPackagesFromProject()
        {
            var project = this.context.Projects.First();
            var packages = project.Packages;

            Assert.IsTrue(packages.Any(), "packages.Any()");
        }

        /// <summary>
        /// The should be able to create an execution.
        /// </summary>
        [Test]
        public void ShouldBeAbleToStartAndFinishAnExecution()
        {
            var executionid = this.context.CreateExecution(Data.PackageName, Data.FolderName, Data.ProjectName);

            Assert.IsTrue(executionid > 0, "executionid > 0");

            this.context.SetExecutionParameterValue(executionid, Data.ObjectType, Data.ParameterName, Data.ParameterValue);
            this.context.StartExecution(executionid);

            // created(1), running(2), canceled(3), failed(4), pending(5), ended unexpectedly (6), succeeded(7), stopping(8), and completed(9).
            int status;
            do
            {
                this.context.Dispose();
                this.context = new IntegrationServicesContext();

                var operation = this.context.Operations.First(o => o.OperationId == executionid);
                status = operation.Status;

                Console.WriteLine($"Status: {status}");

                System.Threading.Thread.Sleep(100);
            }
            while (Data.OperationRunningStatuses.Contains(status));
        }

        /// <summary>
        /// The data.
        /// </summary>
        private static class Data
        {
            /// <summary>
            /// The package name.
            /// </summary>
            public const string PackageName = "Lesson 6.dtsx";

            /// <summary>
            /// The folder name.
            /// </summary>
            public const string FolderName = "SSIS Tutorial";

            /// <summary>
            /// The project name.
            /// </summary>
            public const string ProjectName = "SSIS Tutorial Deployment";

            /// <summary>
            /// The object type.
            /// </summary>
            public const short ObjectType = 30;

            /// <summary>
            /// The parameter name.
            /// </summary>
            public const string ParameterName = "VarFolderName";

            /// <summary>
            /// The parameter value.
            /// </summary>
            public const string ParameterValue = @"C:\temp\SSIS Tutorial Sample Data\Currencies";

            /// <summary>
            /// The operation stopped statuses.
            /// </summary>
            public static readonly int[] OperationStoppedStatuses = { 3, 4, 6, 7, 8 };

            public static readonly int[] OperationRunningStatuses = { 1, 2, 5 };
        }
    }
}