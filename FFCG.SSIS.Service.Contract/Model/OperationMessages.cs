// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationMessages.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The operation messages.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Model
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The operation messages.
    /// </summary>
    [CollectionDataContract(Name = "OperationMessages", Namespace = Constants.Namespace, ItemName = "OperationMessage")]
    public class OperationMessages : List<OperationMessage>
    {
        public OperationMessages()
        {
        }

        public OperationMessages(IEnumerable<OperationMessage> messages)
            : base(messages)
        {
        }
    }
}