// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parameters.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the Parameters type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.PackageRunner.Contract.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The start parameters.
    /// </summary>
    [CollectionDataContract(Name = "Parameters", Namespace = Constants.Namespace, ItemName = "Parameter")]
    public class Parameters
    {
        
    }
}