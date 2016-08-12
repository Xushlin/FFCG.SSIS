// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectType.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The object type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Operation
{
    /// <summary>
    /// The object type.
    /// </summary>
    public enum ObjectType
    {
        /// <summary>
        /// The folder.
        /// </summary>
        Folder  = 10,

        /// <summary>
        /// The project.
        /// </summary>
        Project = 20,

        /// <summary>
        /// The package.
        /// </summary>
        Package = 30,

        /// <summary>
        /// The environment.
        /// </summary>
        Environment = 40,

        /// <summary>
        /// The instance of execution.
        /// </summary>
        InstanceOfExecution = 50
    }
}