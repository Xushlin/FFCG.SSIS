// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIntegrationServicesContext.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The IntegrationServicesContext interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Data.Interface
{
    using System.Data.Entity;

    using FFCG.SSIS.Core.Data.Model;

    /// <summary>
    /// The IntegrationServicesContext interface.
    /// </summary>
    public interface IIntegrationServicesContext
    {
        /// <summary>
        /// Gets the operations.
        /// </summary>
        IDbSet<Operation> Operations { get; }

        /// <summary>
        /// Gets the folders.
        /// </summary>
        IDbSet<Folder> Folders { get; }

        /// <summary>
        /// Gets the projects.
        /// </summary>
        IDbSet<Project> Projects { get; }

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
        int CreateExecution(string packageName, string folderName, string projectName, int? referenceId = null, bool use32BitRuntime = false);

        /// <summary>
        /// The set execution parameter.
        /// </summary>
        /// <param name="executionId">
        /// The execution id.
        /// </param>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <param name="parameterValue">
        /// The parameter value.
        /// </param>
        void SetExecutionParameter(int executionId, short objectType, string parameterName, string parameterValue);

        /// <summary>
        /// The start execution.
        /// </summary>
        /// <param name="executionId">
        /// The execution id.
        /// </param>
        void StartExecution(int executionId);
    }
}