using System;
using System.Collections.Generic;
using System.Reflection;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp
{
    public interface IDataTransferObjectResolver
    {
        /// <summary>
        /// Returns classes within this assembly, that are decorated with <see cref="DataTransferObjectAttribute"/>.
        /// </summary>
        /// <param name="assembly">Assembly to search.</param>
        /// <returns></returns>
        IEnumerable<Type> GetTypesWithDataTransferObjectAttribute(Assembly assembly);

        /// <summary>
        /// Returns single DTO class associated to this domain class.
        /// Does not take into account generic paramters.
        /// </summary>
        /// <param name="type">Domain class.</param>
        /// <returns></returns>
        Type GetDataTransferObject(Type type);

        /// <summary>
        /// Returns DTO class associated to this domain class.
        /// Converts also generic parameters.
        /// </summary>
        /// <param name="type">Domain class.</param>
        /// <returns></returns>
        Type GetDataTransferObjectRecursive(Type type);

        /// <summary>
        /// Checks if this class has domain object associated.
        /// </summary>
        /// <param name="type">Domain class.</param>
        /// <returns></returns>
        bool HasDataTransferObjectAssociated(Type type);
    }
}