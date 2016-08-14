// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the IUnitOfWork type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface
{
    using System;

    using FFCG.SSIS.Core.Contract.Interface.Folder;
    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Contract.Interface.Package;
    using FFCG.SSIS.Core.Contract.Interface.Project;

    /// <summary>
    /// The UnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the packages.
        /// </summary>
        IPackageRepository Packages { get; }

        /// <summary>
        /// Gets the operations.
        /// </summary>
        IOperationRepository Operations { get; }

        /// <summary>
        /// Gets the projects.
        /// </summary>
        IProjectRepository Projects { get; }

        /// <summary>
        /// Gets the folders.
        /// </summary>
        IFolderRepository Folders { get; }

        /// <summary>
        /// The save.
        /// </summary>
        void Save();
    }
}