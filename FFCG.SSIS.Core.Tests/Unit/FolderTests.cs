// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderTests.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the FolderTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Tests.Unit
{
    using System.Linq;

    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Core.Contract.Interface.Folder;
    using FFCG.SSIS.Core.Contract.Interface.Package;
    using FFCG.SSIS.Core.Logic.Implementation;
    using FFCG.SSIS.Core.Tests.Mocks;

    using NUnit.Framework;

    /// <summary>
    /// The folder tests.
    /// </summary>
    [TestFixture]
    public class FolderTests
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
        private IFolderRepository repository;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.mockContext = new IntegrationServicesContextMock();
            this.objectProvider = new ObjectProvider();
            this.repository = (new UnitOfWork(this.mockContext.Object, this.objectProvider)).Folders;
        }

        /// <summary>
        /// The should be able to list folders.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListFolders()
        {
            var folders = this.repository.List().ToArray();

            Assert.AreEqual(this.mockContext.FolderSet.Count(), folders.Length, "Number of folders.");
        }

        /// <summary>
        /// The should be able to get a single folder.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetASingleFolder()
        {
            var folder = this.repository.Get(IntegrationServicesContextData.FolderId1);

            Assert.IsNotNull(folder, "folder != null");
        }

        /// <summary>
        /// The should be able to list projects from a folder.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListProjectsFromAFolder()
        {
            var folder = this.repository.Get(IntegrationServicesContextData.FolderId1);
            var projects = folder.Projects.ToArray();

            Assert.AreEqual(1, projects.Length);
        }
    }
}