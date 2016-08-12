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
            return this.unitOfWork.Context.Packages.Select(pkg => new PackageBusinessObject(pkg, this.unitOfWork));
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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}