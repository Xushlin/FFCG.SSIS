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

    /// <summary>
    /// The integration services context data.
    /// </summary>
    public static class IntegrationServicesContextData
    {
        /// <summary>
        /// The default seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public static void DefaultSeed(IIntegrationServicesContext context)
        {
            // TODO: Add default seed data here.

            context.SaveChanges();
        }
    }
}