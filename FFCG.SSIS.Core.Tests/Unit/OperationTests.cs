// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationTests.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the OperationTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Tests.Unit
{
    using System.Linq;

    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Core.Contract.Interface.Folder;
    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Logic.Implementation;
    using FFCG.SSIS.Core.Tests.Mocks;
    using FFCG.SSIS.Tools.Logic.Implementation;
    using FFCG.SSIS.Tools.Logic.Interface;

    using NUnit.Framework;

    [TestFixture]
    public class OperationTests
    {
        /// <summary>
        /// The mock context.
        /// </summary>
        private IntegrationServicesContextMock mockContext;

        /// <summary>
        /// The object provider.
        /// </summary>
        private IObjectProvider objectProvider;

        /// <summary>
        /// The repository.
        /// </summary>
        private IOperationRepository repository;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.mockContext = new IntegrationServicesContextMock();
            this.objectProvider = new ObjectProvider();
            this.repository = (new UnitOfWork(this.mockContext.Object, this.objectProvider)).Operations;
        }

        /// <summary>
        /// The should be able to list operations.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListOperations()
        {
            var operations = this.repository.List().ToArray();

            Assert.AreEqual(this.mockContext.OperationSet.Count(), operations.Length, "Number of operations.");
        }

        /// <summary>
        /// The should be able to get an operation.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetAnOperation()
        {
            var operation = this.repository.Get(IntegrationServicesContextData.OperationId1);

            Assert.IsNotNull(operation, "operation != null");
        }

        /// <summary>
        /// The should be able to get a folder.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetAFolder()
        {
            var operation = this.repository.Get(IntegrationServicesContextData.OperationId2);
            var folder = operation.Folder;

            Assert.IsNotNull(folder, "folder != null");
        }

        /// <summary>
        /// The should be able to get a project.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetAProject()
        {
            var operation = this.repository.Get(IntegrationServicesContextData.OperationId3);
            var project = operation.Project;


            Assert.IsNotNull(project, "project != null");
        }

        /// <summary>
        /// The should be able to get a package.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetAPackage()
        {
            var operation = this.repository.Get(IntegrationServicesContextData.OperationId1);
            var package = operation.Package;


            Assert.IsNotNull(package, "package != null");
        }
    }
}