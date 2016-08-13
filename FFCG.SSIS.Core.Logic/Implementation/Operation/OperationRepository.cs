// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationRepository.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The operation repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Logic.Implementation.Operation
{
    using System.Collections.Generic;

    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Core.Contract.Interface.Operation;

    /// <summary>
    /// The operation repository.
    /// </summary>
    internal class OperationRepository : IOperationRepository
    {
        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly UnitOfWork unitOfWork;

        public OperationRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IOperationBusinessObject> List()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="operationId">
        /// The operation id.
        /// </param>
        /// <returns>
        /// The <see cref="IOperationBusinessObject"/>.
        /// </returns>
        public IOperationBusinessObject Get(long operationId)
        {
            throw new System.NotImplementedException();
        }
    }
}