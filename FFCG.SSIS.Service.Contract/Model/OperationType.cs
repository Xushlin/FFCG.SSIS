// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationType.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the OperationType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The operation type.
    /// </summary>
    [DataContract(Name = "OperationType", Namespace = Constants.Namespace)]
    public enum OperationType
    {
        /// <summary>
        /// The integration services initialization.
        /// </summary>
        [EnumMember(Value = "IntegrationServicesInitialization")]
        IntegrationServicesInitialization = 1,

        /// <summary>
        /// The retention window.
        /// </summary>
        [EnumMember(Value = "RetentionWindow")]
        RetentionWindow = 2,

        /// <summary>
        /// The max project version.
        /// </summary>
        [EnumMember(Value = "MaxProjectVersion")]
        MaxProjectVersion = 3,

        /// <summary>
        /// The deploy project.
        /// </summary>
        [EnumMember(Value = "DeployProject")]
        DeployProject = 101,

        /// <summary>
        /// The restore project.
        /// </summary>
        [EnumMember(Value = "RestoreProject")]
        RestoreProject = 106,

        /// <summary>
        /// The create execution.
        /// </summary>
        [EnumMember(Value = "CreateExecution")]
        CreateExecution = 200,

        /// <summary>
        /// The stop operation.
        /// </summary>
        [EnumMember(Value = "StopOperation")]
        StopOperation = 202,

        /// <summary>
        /// The validate project.
        /// </summary>
        [EnumMember(Value = "ValidateProject")]
        ValidateProject = 300,

        /// <summary>
        /// The validate package.
        /// </summary>
        [EnumMember(Value = "ValidatePackage")]
        ValidatePackage = 301,

        /// <summary>
        /// The configure catalog.
        /// </summary>
        [EnumMember(Value = "ConfigureCatalog")]
        ConfigureCatalog = 1000
    }
}