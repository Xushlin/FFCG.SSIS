// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPackageRepository.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The PackageRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Package
{
    using System.Collections.Generic;

    /// <summary>
    /// The PackageRepository interface.
    /// </summary>
    public interface IPackageRepository
    {
        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IPackageBusinessObject> List();

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="projectId">
        /// The project id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IPackageBusinessObject> List(long projectId);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// The <see cref="IPackageBusinessObject"/>.
        /// </returns>
        IPackageBusinessObject Get(long packageId);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="packageName">
        /// The package name.
        /// </param>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <returns>
        /// The <see cref="IPackageBusinessObject"/>.
        /// </returns>
        IPackageBusinessObject Get(string packageName, string projectName, string folderName);
    }
}