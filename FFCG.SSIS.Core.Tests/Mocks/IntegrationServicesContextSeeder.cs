// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntegrationServicesContextSeeder.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The integration services context seeder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Tests.Mocks
{
    using FFCG.SSIS.Core.Data.Interface;

    /// <summary>
    /// The integration services context seeder.
    /// </summary>
    /// <param name="context">
    /// The context.
    /// </param>
    public delegate void IntegrationServicesContextSeeder(IIntegrationServicesContext context);
}