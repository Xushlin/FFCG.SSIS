// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntegrationServicesContext.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   The integration services context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Data.Implementation
{
    using System.Data.Entity;

    using FFCG.SSIS.Core.Data.Interface;
    using FFCG.SSIS.Core.Data.Model;

    /// <summary>
    /// The integration services context.
    /// </summary>
    public class IntegrationServicesContext : DbContext, IIntegrationServicesContext
    {
        /// <summary>
        /// The connection string name.
        /// </summary>
        public const string ConnectionStringName = "name=IntegrationServicesContext";

        public IntegrationServicesContext(
            string connectionString = ConnectionStringName,
            IDatabaseInitializer<IntegrationServicesContext> initializer = default(IDatabaseInitializer<IntegrationServicesContext>)) : base(connectionString)
        {
            Database.SetInitializer(initializer);
        }

        public IDbSet<Operation> Operations => this.Set<Operation>();

        /// <summary>
        /// The create execution.
        /// </summary>
        /// <param name="packageName">
        /// The package name.
        /// </param>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="referenceId">
        /// The reference id.
        /// </param>
        /// <param name="use32BitRuntime">
        /// The use 32 bit runtime.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int CreateExecution(
            string packageName,
            string folderName,
            string projectName,
            int? referenceId = null,
            bool use32BitRuntime = false)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The set execution parameter.
        /// </summary>
        /// <param name="executionId">
        /// The execution id.
        /// </param>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <param name="parameterValue">
        /// The parameter value.
        /// </param>
        public void SetExecutionParameter(int executionId, short objectType, string parameterName, string parameterValue)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The start execution.
        /// </summary>
        /// <param name="executionId">
        /// The execution id.
        /// </param>
        public void StartExecution(int executionId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Operation>().HasKey(e => e.OperationId);
        }
    }
}