// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIntegrationServicesContext.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The IntegrationServicesContext interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.PackageRunner.Data.Interaface
{
    /// <summary>
    /// The IntegrationServicesContext interface.
    /// </summary>
    public interface IIntegrationServicesContext
    {
        /// <summary>
        /// The create execution.
        /// </summary>
        /// <param name="packageName">
        /// The package name.
        /// </param>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="referenceId">
        /// The reference id.
        /// </param>
        /// <param name="use32BitRuntime">
        /// The use 32 bit runtime.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int CreateExecution(
            string packageName,
            string folderName,
            string projectName,
            int? referenceId = null,
            bool use32BitRuntime = false);
    }
}