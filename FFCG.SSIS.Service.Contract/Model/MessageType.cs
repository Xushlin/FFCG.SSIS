// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageType.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the MessageType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The message type.
    /// </summary>
    [DataContract(Name = "MessageType", Namespace = Constants.Namespace)]
    public enum MessageType
    {
        /// <summary>
        /// The unknown.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        Unknown = -1,

        /// <summary>
        /// The error.
        /// </summary>
        [EnumMember(Value = "Error")]
        Error = 120,

        /// <summary>
        /// The warning.
        /// </summary>
        [EnumMember(Value = "Warning")]
        Warning = 110,

        /// <summary>
        /// The information.
        /// </summary>
        [EnumMember(Value = "Information")]
        Information = 70,

        /// <summary>
        /// The pre validate.
        /// </summary>
        [EnumMember(Value = "PreValidate")]
        PreValidate = 10,

        /// <summary>
        /// The post validate.
        /// </summary>
        [EnumMember(Value = "PostValidate")]
        PostValidate = 20,

        /// <summary>
        /// The pre execute.
        /// </summary>
        [EnumMember(Value = "PreExecute")]
        PreExecute = 30,

        /// <summary>
        /// The post execute.
        /// </summary>
        [EnumMember(Value = "PostExecute")]
        PostExecute = 40,

        /// <summary>
        /// The progress.
        /// </summary>
        [EnumMember(Value = "Progress")]
        Progress = 60,

        /// <summary>
        /// The status change.
        /// </summary>
        [EnumMember(Value = "StatusChange")]
        StatusChange = 50,

        /// <summary>
        /// The query cancel.
        /// </summary>
        [EnumMember(Value = "QueryCancel")]
        QueryCancel = 100,

        /// <summary>
        /// The task failed.
        /// </summary>
        [EnumMember(Value = "TaskFailed")]
        TaskFailed = 130,

        /// <summary>
        /// The diagnostic.
        /// </summary>
        [EnumMember(Value = "Diagnostic")]
        Diagnostic = 90,

        /// <summary>
        /// The custom.
        /// </summary>
        [EnumMember(Value = "Custom")]
        Custom = 200,

        /// <summary>
        /// The diagnostic ex.
        /// </summary>
        [EnumMember(Value = "DiagnosticEx")]
        DiagnosticEx = 140,

        /// <summary>
        /// The non diagnostic.
        /// </summary>
        [EnumMember(Value = "NonDiagnostic")]
        NonDiagnostic = 400,

        /// <summary>
        /// The variable value changed.
        /// </summary>
        [EnumMember(Value = "VariableValueChanged")]
        VariableValueChanged = 80
    }
}