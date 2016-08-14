// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOperationService.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the IOperationService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Contract.Interface
{
    using FFCG.SSIS.Service.Contract.Model;

    /// <summary>
    /// The OperationService interface.
    /// </summary>
    public interface IOperationService
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="operationId">
        /// The operation id.
        /// </param>
        /// <returns>
        /// The <see cref="OperationDescription"/>.
        /// </returns>
        OperationDescription Get(long operationId);

        /// <summary>
        /// The get messages.
        /// </summary>
        /// <param name="operationId">
        /// The operation id.
        /// </param>
        /// <returns>
        /// The <see cref="OperationMessages"/>.
        /// </returns>
        OperationMessages ListMessages(long operationId);
    }
}