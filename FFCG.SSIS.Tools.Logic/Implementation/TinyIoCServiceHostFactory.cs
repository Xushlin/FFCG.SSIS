// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TinyIoCServiceHostFactory.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the TinyIoCServiceHostFactory type.
//   Based on: https://gist.github.com/marcusoftnet/1078629
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Tools.Logic.Implementation
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;

    /// <summary>
    /// The tiny io c service host factory.
    /// </summary>
    public class TinyIoCServiceHostFactory : ServiceHostFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TinyIoCServiceHostFactory"/> class.
        /// </summary>
        public TinyIoCServiceHostFactory()
        {
        }

        /// <summary>
        /// The create service host.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <param name="baseAddresses">
        /// The base addresses.
        /// </param>
        /// <returns>
        /// The <see cref="ServiceHost"/>.
        /// </returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new TinyIoCServiceHost(serviceType, baseAddresses);
        }
    }
}