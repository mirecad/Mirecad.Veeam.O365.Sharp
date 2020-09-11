using System;
using Autofac;
using Mirecad.Veeam.O365.Sharp.Models;

namespace Mirecad.Veeam.O365.Sharp.Infrastructure
{
    public sealed class DIContainer
    {
        private static IContainer _container;
        private static readonly object Lock = new object();

        private DIContainer()
        {
            //never used
        }

        /// <summary>
        /// Get dependency injection container.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown, when container was not yet created.</exception>
        public static IContainer Container
        {
            get
            {
                lock (Lock)
                {
                    if (_container == null)
                    {
                        throw new InvalidOperationException("Container was not yet created.");
                    }

                    return _container;
                }
            }
        }

        /// <summary>
        /// Initialize dependency injection container.
        /// </summary>
        /// <param name="client">Parent <see cref="VeeamO365Client"/> client.</param>
        /// <returns>Dependency injection container.</returns>
        /// <exception cref="InvalidOperationException">Thrown, when container was already initialized.</exception>
        public static IContainer Create(VeeamO365Client client)
        {
            lock (Lock)
            {
                if (_container != null)
                {
                    throw new InvalidOperationException("Container was already created.");
                }

                return CreateContainer(client);
            }
        }

        private static IContainer CreateContainer(VeeamO365Client client)
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(client);
            return builder.Build();
        }
    }
}
