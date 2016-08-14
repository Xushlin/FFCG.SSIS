// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPackageService.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the IPackageService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Interface
{
    using FFCG.SSIS.Service.Contract.Model;

    /// <summary>
    /// The PackageService interface.
    /// </summary>
    public interface IPackageService
    {
        /// <summary>
        /// The execute.
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
        /// <param name="packageParameters">
        /// The PackageParameters.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        OperationDescription Execute(string packageName, string projectName, string folderName, PackageParameters packageParameters);

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
        /// The <see cref="PackageDescription"/>.
        /// </returns>
        PackageDescription Get(string packageName, string projectName, string folderName);

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <returns>
        /// The <see cref="PackageDescriptions"/>.
        /// </returns>
        PackageDescriptions List(string projectName, string folderName);
    }
}