// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectBusinessObject.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The project business object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Logic.Implementation.Project
{
    using FFCG.SSIS.Core.Contract.Interface.Project;
    using FFCG.SSIS.Core.Data.Model;

    /// <summary>
    /// The project business object.
    /// </summary>
    internal class ProjectBusinessObject : IProjectBusinessObject
    {
        /// <summary>
        /// The model.
        /// </summary>
        private readonly Project model;

        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly UnitOfWork unitOfWork;

        public ProjectBusinessObject(Project model, UnitOfWork unitOfWork)
        {
            this.model = model;
            this.unitOfWork = unitOfWork;
        }
    }
}