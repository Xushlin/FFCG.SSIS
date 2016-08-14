// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the UnitOfWork type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Logic.Implementation
{
    using System;
    using System.Collections.Generic;

    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Core.Contract.Interface.Folder;
    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Contract.Interface.Package;
    using FFCG.SSIS.Core.Contract.Interface.Project;
    using FFCG.SSIS.Core.Data.Interface;

    /// <summary>
    /// The unit of work.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The dictionary.
        /// </summary>
        private readonly IDictionary<Type, object> dictionary;

        /// <summary>
        /// The object provider.
        /// </summary>
        private readonly IObjectProvider objectProvider;

        public UnitOfWork(IIntegrationServicesContext context, IObjectProvider objectProvider)
        {
            this.Context = context;
            this.objectProvider = objectProvider;
            this.dictionary = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Gets the packages.
        /// </summary>
        public IPackageRepository Packages => this.GetRepository<Package.PackageRepository>();

        /// <summary>
        /// Gets the operations.
        /// </summary>
        public IOperationRepository Operations => this.GetRepository<Operation.OperationRepository>();

        /// <summary>
        /// Gets the projects.
        /// </summary>
        public IProjectRepository Projects => this.GetRepository<Project.ProjectRepository>();

        /// <summary>
        /// Gets the folders.
        /// </summary>
        public IFolderRepository Folders => this.GetRepository<Folder.FolderRepository>();

        /// <summary>
        /// Gets the context.
        /// </summary>
        public IIntegrationServicesContext Context { get; private set; }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Context.Dispose();
        }

        /// <summary>
        /// The save.
        /// </summary>
        public void Save()
        {
            this.Context.SaveChanges();
        }

        private TRepository GetRepository<TRepository>() where TRepository : class
        {
            lock (this.dictionary)
            {
                var repositoryType = typeof(TRepository);
                if (this.dictionary.ContainsKey(repositoryType))
                {
                    return this.dictionary[repositoryType] as TRepository;
                }

                var repository = this.objectProvider.Create<TRepository>(this);
                this.dictionary.Add(repositoryType, repository);
                return repository;
            }
        }
    }
}