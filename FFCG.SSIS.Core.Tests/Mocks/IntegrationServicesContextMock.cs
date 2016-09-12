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
        /// Gets or sets the folder 2.
        /// </summary>
        public Folder Folder2 { get; set; }

        /// <summary>
        /// Gets or sets the folder 1.
        /// </summary>
        public Folder Folder1 { get; set; }

        /// <summary>
        /// Gets or sets the project 2.
        /// </summary>
        public Project Project2 { get; set; }

        /// <summary>
        /// Gets or sets the project 1.
        /// </summary>
        public Project Project1 { get; set; }

        /// <summary>
        /// Gets or sets the package 2.
        /// </summary>
        public Package Package2 { get; set; }

        /// <summary>
        /// Gets or sets the package 1.
        /// </summary>
        public Package Package1 { get; set; }
        
        /// <summary>
        /// Gets or sets the operation 3.
        /// </summary>
        public Operation Operation3 { get; set; }

        /// <summary>
        /// Gets or sets the operation 2.
        /// </summary>
        public Operation Operation2 { get; set; }

        /// <summary>
        /// Gets or sets the operation 1.
        /// </summary>
        public Operation Operation1 { get; set; }

        /// <summary>
        /// Gets or sets the operation message 3.
        /// </summary>
        public OperationMessage OperationMessage3 { get; set; }

        /// <summary>
        /// Gets or sets the operation message 2.
        /// </summary>
        public OperationMessage OperationMessage2 { get; set; }

        /// <summary>
        /// Gets or sets the operation message 1.
        /// </summary>
        public OperationMessage OperationMessage1 { get; set; }

        /// <summary>
        /// Gets or sets the operation message set.
        /// </summary>
        public InMemoryDbSet<OperationMessage> OperationMessageSet { get; set; }

        public Execution Execution2 { get; set; }

        public Execution Execution1 { get; set; }

        public InMemoryDbSet<Execution> ExecutionSet { get; set; }

        /// <summary>
        /// The initialize.
        /// </summary>
        private void Initialize()
        {
            // SETS ///////////////////////////////////////////////////////////
            this.OperationSet = new InMemoryDbSet<Operation>(true);
            this.PackageSet = new InMemoryDbSet<Package>(true);
            this.FolderSet = new InMemoryDbSet<Folder>(true);
            this.ProjectSet = new InMemoryDbSet<Project>(true);
            this.OperationMessageSet = new InMemoryDbSet<OperationMessage>(true);
            this.ExecutionSet = new InMemoryDbSet<Execution>(true);

            // SETUP //////////////////////////////////////////////////////////
            this.SetupGet(ctx => ctx.Operations).Returns(this.OperationSet);
            this.SetupGet(ctx => ctx.Packages).Returns(this.PackageSet);
            this.SetupGet(ctx => ctx.Folders).Returns(this.FolderSet);
            this.SetupGet(ctx => ctx.Projects).Returns(this.ProjectSet);
            this.SetupGet(ctx => ctx.OperationMessages).Returns(this.OperationMessageSet);
            this.SetupGet(ctx => ctx.Executions).Returns(this.ExecutionSet);

            // SEED ///////////////////////////////////////////////////////////
            IntegrationServicesContextData.DefaultSeed(this.Object);

            // FETCH //////////////////////////////////////////////////////////
            this.Package1 = this.PackageSet.First(p => p.PackageId == IntegrationServicesContextData.PackageId1);
            this.Package2 = this.PackageSet.First(p => p.PackageId == IntegrationServicesContextData.PackageId2);
            this.Project1 = this.ProjectSet.First(p => p.ProjectId == IntegrationServicesContextData.ProjectId1);
            this.Project2 = this.ProjectSet.First(p => p.ProjectId == IntegrationServicesContextData.ProjectId2);
            this.Folder1 = this.FolderSet.First(p => p.FolderId == IntegrationServicesContextData.FolderId1);
            this.Folder2 = this.FolderSet.First(p => p.FolderId == IntegrationServicesContextData.FolderId2);
            this.Operation1 = this.OperationSet.First(o => o.OperationId == IntegrationServicesContextData.OperationId1);
            this.Operation2 = this.OperationSet.First(o => o.OperationId == IntegrationServicesContextData.OperationId2);
            this.Operation3 = this.OperationSet.First(o => o.OperationId == IntegrationServicesContextData.OperationId3);
            this.OperationMessage1 = this.OperationMessageSet.First(o => o.OperationMessageId == IntegrationServicesContextData.OperationMessageId1);
            this.OperationMessage2 = this.OperationMessageSet.First(o => o.OperationMessageId == IntegrationServicesContextData.OperationMessageId2);
            this.OperationMessage3 = this.OperationMessageSet.First(o => o.OperationMessageId == IntegrationServicesContextData.OperationMessageId3);
            this.Execution1 = this.ExecutionSet.First(exe => exe.ExecutionId == IntegrationServicesContextData.OperationId1);
            this.Execution2 = this.ExecutionSet.First(exe => exe.ExecutionId == IntegrationServicesContextData.OperationId2);
        }
    }
}