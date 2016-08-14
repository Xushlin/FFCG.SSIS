// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TinyIoCServiceHost.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the TinyIoCServiceHost type.
//   Based on: https://gist.github.com/marcusoftnet/1078629
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Tools.Logic.Implementation
{
    using System;
    using System.ServiceModel;

    /// <summary>
    /// The tiny io c service host.
    /// </summary>
    public class TinyIoCServiceHost : ServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TinyIoCServiceHost"/> class.
        /// </summary>
        public TinyIoCServiceHost()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TinyIoCServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <param name="baseAddresses">
        /// The base addresses.
        /// </param>
        public TinyIoCServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        /// <summary>
        /// The on opening.
        /// </summary>
        protected override void OnOpening()
        {
            this.Description.Behaviors.Add(new TinyIoCServiceBehavior());
            base.OnOpening();
        }
    }
}