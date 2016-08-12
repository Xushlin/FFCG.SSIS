// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPackageService.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the IPackageService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.PackageRunner.Contract.Interace
{
    using System.ServiceModel;

    using FFCG.SSIS.PackageRunner.Contract.Model;

    /// <summary>
    /// The PackageService interface.
    /// </summary>
    [ServiceContract(Namespace = Constants.Namespace, Name = "PackageService")]
    public interface IPackageService
    {
        /// <summary>
        /// The method to start a remote package.
        /// </summary>
        /// <param name="description">
        /// The description of the package to start.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        [OperationContract(Name = "Run")]
        int Start(PackageDescription description);
    }
}