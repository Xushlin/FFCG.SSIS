// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the Global type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Service.Web
{
    using System;
    using System.Web.Configuration;

    /// <summary>
    /// The global.
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// The application_ start.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Application_Start(object sender, EventArgs e)
        {
            var configuration = WebConfigurationManager.OpenWebConfiguration("~");

            IoCConfig.Register(configuration);
        }
    }
}