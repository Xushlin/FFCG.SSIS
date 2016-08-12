// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectTests.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the ProjectTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Tests.Unit
{
    using System.Linq;

    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Core.Contract.Interface.Package;
    using FFCG.SSIS.Core.Contract.Interface.Project;
    using FFCG.SSIS.Core.Logic.Implementation;
    using FFCG.SSIS.Core.Tests.Mocks;

    using NUnit.Framework;

    /// <summary>
    /// The project tests.
    /// </summary>
    [TestFixture]
    public class ProjectTests
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
        private IProjectRepository repository;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.mockContext = new IntegrationServicesContextMock();
            this.objectProvider = new ObjectProvider();
            this.repository = (new UnitOfWork(this.mockContext.Object, this.objectProvider)).Projects;
        }

        /// <summary>
        /// The should be able to list projects.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListProjects()
        {
            var projects = this.repository.List().ToArray();

            Assert.AreEqual(this.mockContext.ProjectSet.Count(), projects.Length, "Number of projects");
        }

        /// <summary>
        /// The should be able to list projects by folder.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListProjectsByFolder()
        {
            var projects = this.repository.List(IntegrationServicesContextData.FolderId1).ToArray();

            Assert.AreEqual(1, projects.Length, "Number of projects");
        }

        /// <summary>
        /// The should be able to get a project by id.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetAProjectById()
        {
            var project = this.repository.Get(IntegrationServicesContextData.ProjectId1);

            Assert.IsNotNull(project, "project != null");
        }
    }
}