// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationType.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the OperationType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Operation
{
    /// <summary>
    /// The operation type.
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// The integration services initialization.
        /// </summary>
        IntegrationServicesInitialization = 1,

        /// <summary>
        /// The retention window.
        /// </summary>
        RetentionWindow = 2,

        /// <summary>
        /// The max project version.
        /// </summary>
        MaxProjectVersion = 3,

        /// <summary>
        /// The deploy project.
        /// </summary>
        DeployProject = 101,

        /// <summary>
        /// The restore project.
        /// </summary>
        RestoreProject = 106,

        /// <summary>
        /// The create execution.
        /// </summary>
        CreateExecution = 200,

        /// <summary>
        /// The stop operation.
        /// </summary>
        StopOperation = 202,

        /// <summary>
        /// The validate project.
        /// </summary>
        ValidateProject = 300,

        /// <summary>
        /// The validate package.
        /// </summary>
        ValidatePackage = 301,

        /// <summary>
        /// The configure catalog.
        /// </summary>
        ConfigureCatalog = 1000
    }
}