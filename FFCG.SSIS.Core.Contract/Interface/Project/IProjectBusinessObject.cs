// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProjectBusinessObject.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the IProjectBusinessObject type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Project
{
    using System;
    using System.Collections.Generic;

    using FFCG.SSIS.Core.Contract.Interface.Folder;
    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Contract.Interface.Package;

    /// <summary>
    /// The ProjectBusinessObject interface.
    /// </summary>
    public interface IProjectBusinessObject
    {
        /// <summary>
        /// Gets the project id.
        /// </summary>
        long ProjectId { get; }

        /// <summary>
        /// Gets the folder id.
        /// </summary>
        long FolderId { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the project format version.
        /// </summary>
        int? ProjectFormatVersion { get; }

        /// <summary>
        /// Gets the deployed by sid.
        /// </summary>
        byte[] DeployedBySid { get; }

        /// <summary>
        /// Gets the deployed by name.
        /// </summary>
        string DeployedByName { get; }

        /// <summary>
        /// Gets the last deployed time.
        /// </summary>
        DateTimeOffset LastDeployedTime { get; }

        /// <summary>
        /// Gets the created time.
        /// </summary>
        DateTimeOffset CreatedTime { get; }

        /// <summary>
        /// Gets the object version.
        /// </summary>
        long ObjectVersion { get; }

        /// <summary>
        /// Gets the validation status.
        /// </summary>
        char ValidationStatus { get; }

        /// <summary>
        /// Gets the last validation time.
        /// </summary>
        DateTimeOffset? LastValidationTime { get; }

        /// <summary>
        /// Gets the folder.
        /// </summary>
        IFolderBusinessObject Folder { get; }

        /// <summary>
        /// Gets the packages.
        /// </summary>
        IEnumerable<IPackageBusinessObject> Packages { get; }

        /// <summary>
        /// Gets the operations.
        /// </summary>
        IEnumerable<IOperationBusinessObject> Operations { get; }
    }
}