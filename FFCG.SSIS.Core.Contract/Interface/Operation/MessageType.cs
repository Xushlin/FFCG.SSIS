// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageType.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the MessageType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Operation
{
    /// <summary>
    /// The message type.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// The unknown.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// The error.
        /// </summary>
        Error = 120,

        /// <summary>
        /// The warning.
        /// </summary>
        Warning = 110,

        /// <summary>
        /// The information.
        /// </summary>
        Information = 70,

        /// <summary>
        /// The pre validate.
        /// </summary>
        PreValidate = 10,

        /// <summary>
        /// The post validate.
        /// </summary>
        PostValidate = 20,

        /// <summary>
        /// The pre execute.
        /// </summary>
        PreExecute = 30,

        /// <summary>
        /// The post execute.
        /// </summary>
        PostExecute = 40,

        /// <summary>
        /// The progress.
        /// </summary>
        Progress = 60,

        /// <summary>
        /// The status change.
        /// </summary>
        StatusChange = 50,

        /// <summary>
        /// The query cancel.
        /// </summary>
        QueryCancel = 100,

        /// <summary>
        /// The task failed.
        /// </summary>
        TaskFailed = 130,

        /// <summary>
        /// The diagnostic.
        /// </summary>
        Diagnostic = 90,

        /// <summary>
        /// The custom.
        /// </summary>
        Custom = 200,

        /// <summary>
        /// The diagnostic ex.
        /// </summary>
        DiagnosticEx = 140,

        /// <summary>
        /// The non diagnostic.
        /// </summary>
        NonDiagnostic = 400,

        /// <summary>
        /// The variable value changed.
        /// </summary>
        VariableValueChanged = 80
    }
}