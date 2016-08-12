// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationBusinessObject.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the OperationBusinessObject type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Logic.Implementation.Operation
{
    using FFCG.SSIS.Core.Contract.Interface.Operation;
    using FFCG.SSIS.Core.Data.Model;

    /// <summary>
    /// The operation business object.
    /// </summary>
    internal class OperationBusinessObject : IOperationBusinessObject
    {
        /// <summary>
        /// The model.
        /// </summary>
        private readonly Operation model;

        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly UnitOfWork unitOfWork;

        public OperationBusinessObject(Operation model, UnitOfWork unitOfWork)
        {
            this.model = model;
            this.unitOfWork = unitOfWork;
        }
    }
}