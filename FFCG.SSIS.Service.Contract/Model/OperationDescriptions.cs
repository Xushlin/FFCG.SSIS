// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationDescription.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the OperationDescription type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The operation descriptions.
    /// </summary>
    [CollectionDataContract(Name = "OperationDescriptions", Namespace = Constants.Namespace, ItemName = "OperationDescription")]
    public class OperationDescriptions : List<OperationDescription>
    {
        public OperationDescriptions()
        {
        }

        public OperationDescriptions(IEnumerable<OperationDescription> messages)
            : base(messages)
        {
        }
    }
}