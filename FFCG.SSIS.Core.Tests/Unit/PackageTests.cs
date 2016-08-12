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
    using FFCG.SSIS.Core.Contract.Interface.Package;
    using FFCG.SSIS.Core.Logic.Implementation;
    using FFCG.SSIS.Core.Tests.Mocks;

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
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.mockContext = new IntegrationServicesContextMock();
            this.objectProvider = new ObjectProvider();
            this.repository = (new UnitOfWork(this.mockContext.Object, this.objectProvider)).Packages;
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
    }
}