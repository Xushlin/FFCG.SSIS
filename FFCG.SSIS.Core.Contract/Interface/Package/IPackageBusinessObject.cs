// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPackageBusinessObject.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the IPackageBusinessObject type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Package
{
    using System;
    using System.Collections.Generic;

    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Contract.Interface.Project;
    using FFCG.SSIS.Core.Data.Model;

    /// <summary>
    /// The PackageBusinessObject interface.
    /// </summary>
    public interface IPackageBusinessObject
    {
        /// <summary>
        /// Gets the package id.
        /// </summary>
        long PackageId { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the package guid.
        /// </summary>
        Guid PackageGuid { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the package format version.
        /// </summary>
        int PackageFormatVersion { get; }

        /// <summary>
        /// Gets the version major.
        /// </summary>
        int VersionMajor { get; }

        /// <summary>
        /// Gets the version minor.
        /// </summary>
        int VersionMinor { get; }

        /// <summary>
        /// Gets the version build.
        /// </summary>
        int VersionBuild { get; }

        /// <summary>
        /// Gets the version comments.
        /// </summary>
        string VersionComments { get; }

        /// <summary>
        /// Gets the version GUID.
        /// </summary>
        Guid VersionGuid { get; }
        
        /// <summary>
        /// Gets a value indicating whether entry point.
        /// </summary>
        bool EntryPoint { get; }

        /// <summary>
        /// Gets the validation status.
        /// </summary>
        char ValidationStatus { get; }

        /// <summary>
        /// Gets the last validation time.
        /// </summary>
        DateTimeOffset? LastValidationTime { get;  }

        /// <summary>
        /// Gets the project.
        /// </summary>
        IProjectBusinessObject Project { get; }

        /// <summary>
        /// Gets the operations.
        /// </summary>
        IEnumerable<IOperationBusinessObject> Operations { get; }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="IOperationBusinessObject"/>.
        /// </returns>
        IOperationBusinessObject Execute(IEnumerable<PackageParameter> parameters);
    }
}