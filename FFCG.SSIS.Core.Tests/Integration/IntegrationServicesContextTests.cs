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
    using System.Linq;

    using FFCG.SSIS.Core.Data.Implementation;
    using FFCG.SSIS.Core.Data.Interface;

    using NUnit.Framework;

    /// <summary>
    /// The integration services context tests.
    /// </summary>
    [TestFixture]
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
    }
}