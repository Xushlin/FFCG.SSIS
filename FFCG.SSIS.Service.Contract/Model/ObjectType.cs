// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectType.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The object type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The object type.
    /// </summary>
    [DataContract(Name = "ObjectType", Namespace = Constants.Namespace)]
    public enum ObjectType
    {
        /// <summary>
        /// The server level.
        /// </summary>
        [EnumMember(Value = "Server")]
        Server = 50,

        /// <summary>
        /// The project.
        /// </summary>
        [EnumMember(Value = "Project")]
        Project = 20,

        /// <summary>
        /// The package.
        /// </summary>
        [EnumMember(Value = "Package")]
        Package = 30
    }
}
