﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntegrationServicesContextTests.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the IntegrationServicesContextTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Tests.Integration
{
    using System.Linq;

    using FFCG.SSIS.Core.Data.Implementation;
    using FFCG.SSIS.Core.Data.Interface;

    using NUnit.Framework;

    /// <summary>
    /// The integration services context tests.
    /// </summary>
    [TestFixture]
    public class IntegrationServicesContextTests
    {
        /// <summary>
        /// The context.
        /// </summary>
        private IIntegrationServicesContext context;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.context = new IntegrationServicesContext();
        }

        /// <summary>
        /// The should be able to find an operation.
        /// </summary>
        [Test]
        public void ShouldBeAbleToFindAnOperation()
        {
            var operation = this.context.Operations.FirstOrDefault();

            Assert.IsNotNull(operation, "operation != null");
        }
    }
}