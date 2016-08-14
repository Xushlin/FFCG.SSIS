// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageRepository.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the PackageRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Logic.Implementation.Package
{
    using System.Collections.Generic;
    using System.Linq;

    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Core.Contract.Interface.Package;
    using FFCG.SSIS.Core.Data.Model;

    /// <summary>
    /// The package repository.
    /// </summary>
    internal class PackageRepository : IPackageRepository
    {
        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly UnitOfWork unitOfWork;

        public PackageRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IPackageBusinessObject> List()
        {
            return this.unitOfWork.Context.Packages
                .AsEnumerable()
                .Select(pkg => new PackageBusinessObject(pkg, this.unitOfWork));
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="projectId">
        /// The project id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IPackageBusinessObject> List(long projectId)
        {
            return this.unitOfWork.Context.Packages
                .Where(pkg => pkg.ProjectId == projectId)
                .AsEnumerable()
                .Select(pkg => new PackageBusinessObject(pkg, this.unitOfWork));
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// The <see cref="IPackageBusinessObject"/>.
        /// </returns>
        public IPackageBusinessObject Get(long packageId)
        {
            var package = this.unitOfWork.Context.Packages.First(pkg => pkg.PackageId == packageId);

            return new PackageBusinessObject(package, this.unitOfWork);
        }

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
        public IPackageBusinessObject Get(string packageName, string projectName, string folderName)
        {
            var folder = this.unitOfWork.Context.Folders.First(f => f.Name == folderName);
            var project = folder.Projects.First(proj => proj.Name == projectName);
            var package = project.Packages.First(pkg => pkg.Name == packageName);
            
            return new PackageBusinessObject(package, this.unitOfWork);
        }
    }
}