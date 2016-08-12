// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntegrationServicesContextData.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The integration services context data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Tests.Mocks
{
    using FFCG.SSIS.Core.Data.Interface;
    using FFCG.SSIS.Core.Data.Model;

    /// <summary>
    /// The integration services context data.
    /// </summary>
    public static class IntegrationServicesContextData
    {
        /// <summary>
        /// The package id 1.
        /// </summary>
        public const long PackageId1 = 1;

        /// <summary>
        /// The package id 2.
        /// </summary>
        public const long PackageId2 = 2;

        /// <summary>
        /// The package name 1.
        /// </summary>
        public const string PackageName1 = "PACKAGE_1";

        /// <summary>
        /// The package name 2.
        /// </summary>
        public const string PackageName2 = "PACKAGE_2";

        /// <summary>
        /// The project id 1.
        /// </summary>
        public const long ProjectId1 = 3;

        /// <summary>
        /// The project id 2.
        /// </summary>
        public const long ProjectId2 = 4;

        /// <summary>
        /// The default seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public static void DefaultSeed(IIntegrationServicesContext context)
        {
            var package1 = new Package
            {
                PackageId = PackageId1,
                Name = PackageName1,
                ProjectId = ProjectId1
            };

            var package2 = new Package
            {
                PackageId = PackageId2,
                Name = PackageName2,
                ProjectId = ProjectId2
            };

            context.Packages.Add(package1);
            context.Packages.Add(package2);

            context.SaveChanges();
        }
    }
}