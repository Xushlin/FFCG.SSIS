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
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;

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

        #region SQL

        private const string CreateExecutionSql = @"EXEC [catalog].[create_execution] 
@package_name=@packageName, 
@folder_name=@folderName, 
@project_name=@projectName, 
@use32bitruntime=@use32BitRuntime, 
@reference_id=@referenceId, 
@execution_id=@executionId OUTPUT";

        private const string SetExecutionParameterValueSql = @"EXEC [catalog].[set_execution_parameter_value] 
@execution_id=@executionId, 
@object_type=@objectType, 
@parameter_name=@parameterName, 
@parameter_value=@parameterValue";

        private const string StartExecutionSql = @"EXEC [catalog].[start_execution] @execution_id=@executionId";

        #endregion // SQL

        public IntegrationServicesContext(
            string connectionString = ConnectionStringName,
            IDatabaseInitializer<IntegrationServicesContext> initializer = default(IDatabaseInitializer<IntegrationServicesContext>)) : base(connectionString)
        {
            Database.SetInitializer(initializer);
        }

        public IDbSet<Operation> Operations => this.Set<Operation>();

        public IDbSet<Folder> Folders => this.Set<Folder>();

        public IDbSet<Project> Projects => this.Set<Project>();

        public IDbSet<Package> Packages => this.Set<Package>();

        public IDbSet<EventMessage> EventMessages => this.Set<EventMessage>();

        public IDbSet<OperationMessage> OperationMessages => this.Set<OperationMessage>();

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
        public long CreateExecution(
            string packageName,
            string folderName,
            string projectName,
            int? referenceId = null,
            bool use32BitRuntime = false)
        {
            var packageNameParam = new SqlParameter("packageName", SqlDbType.NVarChar, 260) { Value = (object)packageName ?? DBNull.Value };
            var folderNameParam = new SqlParameter("folderName", SqlDbType.NVarChar, 128) { Value = (object)folderName ?? DBNull.Value };
            var projectNameParam = new SqlParameter("projectName", SqlDbType.NVarChar, 128) { Value = (object)projectName ?? DBNull.Value };
            var use32BitRuntimeParam = new SqlParameter("use32BitRuntime", SqlDbType.Bit) { Value = use32BitRuntime };
            var referenceIdParam = new SqlParameter("referenceId", SqlDbType.Int) { Value = (object)referenceId ?? DBNull.Value };
            var executionIdParam = new SqlParameter("executionId", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
            
            this.Database.ExecuteSqlCommand(CreateExecutionSql, packageNameParam, folderNameParam, projectNameParam, use32BitRuntimeParam, referenceIdParam, executionIdParam);

            return (long)executionIdParam.Value;
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
        public void SetExecutionParameterValue(long executionId, short objectType, string parameterName, object parameterValue)
        {
            var executionIdParam = new SqlParameter("executionId", SqlDbType.BigInt) { Value = executionId };
            var objectTypeParam = new SqlParameter("objectType", SqlDbType.SmallInt) { Value = objectType };
            var parameterNameParam = new SqlParameter("parameterName", SqlDbType.NVarChar, 128) { Value = parameterName };
            var parameterValueParam = new SqlParameter("parameterValue", SqlDbType.Variant) { Value = parameterValue };

            this.Database.ExecuteSqlCommand(SetExecutionParameterValueSql, executionIdParam, objectTypeParam, parameterNameParam, parameterValueParam);
        }

        public void StartExecution(long executionId)
        {
            var executionIdParam = new SqlParameter("executionId", SqlDbType.BigInt) { Value = executionId };

            this.Database.ExecuteSqlCommand(StartExecutionSql, executionIdParam);
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
            modelBuilder.Entity<Folder>().HasKey(f => f.FolderId);
            modelBuilder.Entity<Project>().HasKey(p => p.ProjectId)
                .HasRequired(p => p.Folder)
                .WithMany(f => f.Projects)
                .HasForeignKey(p => p.FolderId);
            modelBuilder.Entity<Package>()
                .HasKey(pkg => pkg.PackageId)
                .HasRequired(pkg => pkg.Project)
                .WithMany(p => p.Packages)
                .HasForeignKey(pkg => pkg.ProjectId);
            modelBuilder.Entity<EventMessage>()
                .HasKey(em => em.EventMessageId)
                .HasRequired(em => em.Operation)
                .WithMany(op => op.EventMessages)
                .HasForeignKey(em => em.OperationId);
            modelBuilder.Entity<OperationMessage>().HasKey(opm => opm.OperationMessageId)
                .HasRequired(opm => opm.Operation)
                .WithMany(op => op.OperationMessages)
                .HasForeignKey(opm => opm.OperationId); ;
        }
    }
}