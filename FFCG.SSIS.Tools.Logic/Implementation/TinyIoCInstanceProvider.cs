// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TinyIoCInstanceProvider.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the TinyIoCInstanceProvider type.
//   Based on: https://gist.github.com/marcusoftnet/1078629
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Tools.Logic.Implementation
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;

    using TinyIoC;

    /// <summary>
    /// The tiny io c instance provider.
    /// </summary>
    public class TinyIoCInstanceProvider : IInstanceProvider
    {
        /// <summary>
        /// The service type.
        /// </summary>
        private readonly Type serviceType;

        /// <summary>
        /// Initializes a new instance of the <see cref="TinyIoCInstanceProvider"/> class.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        public TinyIoCInstanceProvider(Type serviceType)
        {
            this.serviceType = serviceType;
        }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <param name="instanceContext">
        /// The instance context.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetInstance(InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <param name="instanceContext">
        /// The instance context.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return TinyIoCContainer.Current.Resolve(this.serviceType);
        }

        /// <summary>
        /// The release instance.
        /// </summary>
        /// <param name="instanceContext">
        /// The instance context.
        /// </param>
        /// <param name="instance">
        /// The instance.
        /// </param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}