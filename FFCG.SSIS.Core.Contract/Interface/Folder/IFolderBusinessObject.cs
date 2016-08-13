// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFolderBusinessObject.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The FolderBusinessObject interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Folder
{
    using System;
    using System.Collections.Generic;

    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Contract.Interface.Project;

    /// <summary>
    /// The FolderBusinessObject interface.
    /// </summary>
    public interface IFolderBusinessObject
    {
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
        /// Gets the created by sid.
        /// </summary>
        byte[] CreatedBySid { get; }

        /// <summary>
        /// Gets the created by name.
        /// </summary>
        string CreatedByName { get; }

        /// <summary>
        /// Gets the created time.
        /// </summary>
        DateTimeOffset CreatedTime { get; }

        /// <summary>
        /// Gets the projects.
        /// </summary>
        IEnumerable<IProjectBusinessObject> Projects { get; }

        /// <summary>
        /// Gets the operations.
        /// </summary>
        IEnumerable<IOperationBusinessObject> Operations { get; }
    }
}