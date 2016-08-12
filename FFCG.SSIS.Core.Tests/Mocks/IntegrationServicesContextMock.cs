// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntegrationServicesContextMock.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The integration services context mock.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Tests.Mocks
{
    using System.Linq;

    using FakeDbSet;

    using FFCG.SSIS.Core.Data.Interface;
    using FFCG.SSIS.Core.Data.Model;

    using Moq;

    /// <summary>
    /// The integration services context mock.
    /// </summary>
    public class IntegrationServicesContextMock : Mock<IIntegrationServicesContext>
    {
        
        public IntegrationServicesContextMock()
        {
            this.Initialize();
        }

        /// <summary>
        /// Gets the operation set.
        /// </summary>
        public InMemoryDbSet<Operation> OperationSet { get; private set; }

        /// <summary>
        /// Gets or sets the project set.
        /// </summary>
        public InMemoryDbSet<Project> ProjectSet { get; set; }

        /// <summary>
        /// Gets or sets the folder set.
        /// </summary>
        public InMemoryDbSet<Folder> FolderSet { get; set; }

        /// <summary>
        /// Gets or sets the package set.
        /// </summary>
        public InMemoryDbSet<Package> PackageSet { get; set; }

        /// <summary>
        /// The initialize.
        /// </summary>
        private void Initialize()
        {
            // SETS ///////////////////////////////////////////////////////////
            this.OperationSet = new InMemoryDbSet<Operation>();
            this.PackageSet = new InMemoryDbSet<Package>();
            this.FolderSet = new InMemoryDbSet<Folder>();
            this.ProjectSet = new InMemoryDbSet<Project>();

            // SETUP //////////////////////////////////////////////////////////
            this.SetupGet(ctx => ctx.Operations).Returns(this.OperationSet);
            this.SetupGet(ctx => ctx.Packages).Returns(this.PackageSet);
            this.SetupGet(ctx => ctx.Folders).Returns(this.FolderSet);
            this.SetupGet(ctx => ctx.Projects).Returns(this.ProjectSet);

            // SEED ///////////////////////////////////////////////////////////
            IntegrationServicesContextData.DefaultSeed(this.Object);

            // FETCH //////////////////////////////////////////////////////////
            this.Package1 = this.PackageSet.First(p => p.PackageId == IntegrationServicesContextData.PackageId1);
            this.Package2 = this.PackageSet.First(p => p.PackageId == IntegrationServicesContextData.PackageId2);
        }

        public Package Package2 { get; set; }

        /// <summary>
        /// Gets or sets the package 1.
        /// </summary>
        public Package Package1 { get; set; }
    }
}