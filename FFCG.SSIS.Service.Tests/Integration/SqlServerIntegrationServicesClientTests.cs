// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlServerIntegrationServicesClientTests.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the SqlServerIntegrationServicesClientTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Tests.Integration
{
    using System.Linq;

    using FFCG.SSIS.Service.Client.Implementation;
    using FFCG.SSIS.Service.Contract.Interface;

    using NUnit.Framework;

    /// <summary>
    /// The sql server integration services client tests.
    /// </summary>
    [TestFixture]
    public class SqlServerIntegrationServicesClientTests
    {
        /// <summary>
        /// The client.
        /// </summary>
        private ISqlServerIntegrationServicesService client;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.client = new SqlServerIntegrationServicesClient("SqlServerIntegrationServicesClient");
        }

        /// <summary>
        /// The should be able to list folders.
        /// </summary>
        [Test]
        public void ShouldBeAbleToListFolders()
        {
            var folders = this.client.ListFolders();

            Assert.IsTrue(folders.Any(), "folders.Any()");
        }
    }
}