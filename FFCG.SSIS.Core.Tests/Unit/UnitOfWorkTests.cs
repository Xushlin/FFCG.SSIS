// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWorkTests.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the UnitOfWorkTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Tests.Unit
{
    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Core.Data.Interface;
    using FFCG.SSIS.Core.Logic.Implementation;

    using Moq;

    using NUnit.Framework;

    /// <summary>
    /// The unit of work tests.
    /// </summary>
    [TestFixture]
    public class UnitOfWorkTests
    {
        /// <summary>
        /// The mock context.
        /// </summary>
        private Mock<IIntegrationServicesContext> mockContext;

        /// <summary>
        /// The unit of work.
        /// </summary>
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// The object provider.
        /// </summary>
        private IObjectProvider objectProvider;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.mockContext = new Mock<IIntegrationServicesContext>();
            this.objectProvider = new ObjectProvider();

            this.unitOfWork = new UnitOfWork(this.mockContext.Object, this.objectProvider);
        }

        /// <summary>
        /// The should be able to get a package repository.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetAPackageRepository()
        {
            var packages1 = this.unitOfWork.Packages;

            Assert.IsNotNull(packages1, "packages != null");
        }

        /// <summary>
        /// The multiple calls to packages should result in the same object.
        /// </summary>
        [Test]
        public void MultipleCallsToPackagesShouldResultInTheSameObject()
        {
            var packages1 = this.unitOfWork.Packages;
            var packages2 = this.unitOfWork.Packages;

            Assert.AreSame(packages1, packages2, "packages");
        }

        /// <summary>
        /// The should be able to get operations repository.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetOperationsRepository()
        {
            var operations = this.unitOfWork.Operations;

            Assert.IsNotNull(operations, "operations != null");
        }

        /// <summary>
        /// The multiple calls to operations should result in the same object.
        /// </summary>
        [Test]
        public void MultipleCallsToOperationsShouldResultInTheSameObject()
        {
            var operations1 = this.unitOfWork.Operations;
            var operations2 = this.unitOfWork.Operations;

            Assert.AreSame(operations1, operations2, "operations");
        }

        /// <summary>
        /// The should be able to get projects repository.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetProjectsRepository()
        {
            var projects = this.unitOfWork.Projects;

            Assert.IsNotNull(projects, "projects != null");
        }

        /// <summary>
        /// The multiple calls to projects should result in the same object.
        /// </summary>
        [Test]
        public void MultipleCallsToProjectsShouldResultInTheSameObject()
        {
            var projects1 = this.unitOfWork.Projects;
            var projects2 = this.unitOfWork.Projects;

            Assert.AreSame(projects1, projects2, "projects");
        }


        /// <summary>
        /// The should be able to get folders repository.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetFoldersRepository()
        {
            var folders = this.unitOfWork.Folders;

            Assert.IsNotNull(folders, "folders != null");
        }

        /// <summary>
        /// The multiple calls to folders should result in the same object.
        /// </summary>
        [Test]
        public void MultipleCallsToFoldersShouldResultInTheSameObject()
        {
            var folders1 = this.unitOfWork.Folders;
            var folders2 = this.unitOfWork.Folders;

            Assert.AreSame(folders1, folders2, "folders");
        }
    }
}