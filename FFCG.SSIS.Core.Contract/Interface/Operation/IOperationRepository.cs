// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOperationRepository.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The OperationRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Contract.Interface.Operation
{
    using System.Collections.Generic;

    /// <summary>
    /// The OperationRepository interface.
    /// </summary>
    public interface IOperationRepository
    {
        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IOperationBusinessObject> List();

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="operationId">
        /// The operation id.
        /// </param>
        /// <returns>
        /// The <see cref="IOperationBusinessObject"/>.
        /// </returns>
        IOperationBusinessObject Get(long operationId);


    }
}