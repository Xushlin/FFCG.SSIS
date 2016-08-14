// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageTests.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The package tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Tests.Unit
{
    using System.Linq;

    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Contract.Interface.Package;
    using FFCG.SSIS.Core.Logic.Implementation;
    using FFCG.SSIS.Core.Tests.Mocks;
    using FFCG.SSIS.Tools.Logic.Implementation;
    using FFCG.SSIS.Tools.Logic.Interface;

    using Moq;

    using NUnit.Framework;

    /// <summary>
    /// The package tests.
    /// </summary>
    [TestFixture]
    public class PackageTests
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
        private IPackageRepository repository;

        /// <summary>
        /// The parameters.
        /// </summary>
        private PackageParameter[] parameters;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.mockContext = new IntegrationServicesContextMock();
            this.objectProvider = new ObjectProvider();
            this.repository = (new UnitOfWork(this.mockContext.Object, this.objectProvider)).Packages;

            this.parameters = new[]
            {
                new PackageParameter
                {
                    ParameterName = Data.ParameterName1,
                    Value = Data.ParameterValue1,
                    ObjectType = Data.ParameterObjectType1
                },
                new PackageParameter
                {
                    ParameterName = Data.ParameterName2,
                    Value = Data.ParameterValue2,
                    ObjectType = Data.ParameterObjectType2
                }
            };

            this.mockContext.Setup(ctx => ctx.CreateExecution(IntegrationServicesContextData.PackageName1, IntegrationServicesContextData.FolderName1, IntegrationServicesContextData.ProjectName1, null, false)).Returns(IntegrationServicesContextData.OperationId1);
        }

        /// <summary>
        /// The should be able to list packages.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListPackages()
        {
            var packages = this.repository.List().ToArray();

            Assert.AreEqual(this.mockContext.PackageSet.Count(), packages.Length, "Number of packages");
        }

        /// <summary>
        /// The should be able to list packages with a certain project.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListPackagesWithACertainProject()
        {
            var packages = this.repository.List(IntegrationServicesContextData.ProjectId1).ToArray();

            Assert.AreEqual(1, packages.Length, "Single package");
        }

        /// <summary>
        /// The should be able to get a single package.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetASinglePackage()
        {
            var package = this.repository.Get(IntegrationServicesContextData.PackageId1);

            Assert.IsNotNull(package, "package != null");
        }

        /// <summary>
        /// The should be able to get operations.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetOperations()
        {
            var package = this.repository.Get(IntegrationServicesContextData.PackageId1);
            var operations = package.Operations.ToArray();

            Assert.AreEqual(1, operations.Length, "number of operations");
            Assert.IsTrue(operations.Any(op => op.OperationId == IntegrationServicesContextData.OperationId1), "operations.Any(op => op.OperationId == IntegrationServicesContextData.OperationId1)");
        }

        /// <summary>
        /// The should be able to execute a package.
        /// </summary>
        [Test]
        public void ShouldBeAbleToExecuteAPackage()
        {
            var package = this.repository.Get(IntegrationServicesContextData.PackageId1);
            var operation = package.Execute(this.parameters);

            Assert.IsNotNull(operation, "operation != null");

            this.mockContext.Verify(ctx => ctx.CreateExecution(IntegrationServicesContextData.PackageName1, IntegrationServicesContextData.FolderName1, IntegrationServicesContextData.ProjectName1, null, false), Times.Once);
            this.mockContext.Verify(ctx => ctx.SetExecutionParameterValue(IntegrationServicesContextData.OperationId1, (short)Data.ParameterObjectType1, Data.ParameterName1, Data.ParameterValue1), Times.Once);
            this.mockContext.Verify(ctx => ctx.SetExecutionParameterValue(IntegrationServicesContextData.OperationId1, (short)Data.ParameterObjectType2, Data.ParameterName2, Data.ParameterValue2), Times.Once);
            this.mockContext.Verify(ctx => ctx.StartExecution(IntegrationServicesContextData.OperationId1), Times.Once);
        }

        /// <summary>
        /// The should be able to fetch a package through name.
        /// </summary>
        [Test]
        public void ShouldBeAbleToFetchAPackageThroughName()
        {
            var package = this.repository.Get(IntegrationServicesContextData.PackageName1, IntegrationServicesContextData.ProjectName1, IntegrationServicesContextData.FolderName1);

            Assert.IsNotNull(package, "package != null");
            Assert.AreEqual(IntegrationServicesContextData.PackageId1, package.PackageId, "PackageId");
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
            public const int ParameterValue1 = 99;

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