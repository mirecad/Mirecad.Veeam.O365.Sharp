using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp
{
    public class DataTransferObjectResolver : IDataTransferObjectResolver
    {
        public IEnumerable<Type> GetTypesWithDataTransferObjectAttribute(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(DataTransferObjectAttribute), true).Length > 0)
                {
                    yield return type;
                }
            }
        }

        public Type GetDataTransferObjectRecursive(Type type)
        {
            var dtoType = GetDataTransferObject(type);
            if (type.IsGenericType)
            {
                var genericType = type.GetGenericArguments().Single();
                var genericDtoType = GetDataTransferObjectRecursive(genericType);
                dtoType = dtoType.GetGenericTypeDefinition().MakeGenericType(genericDtoType);
            }

            return dtoType;
        }

        public Type GetDataTransferObject(Type type)
        {
            var dtoAttribute = type.GetCustomAttribute(typeof(DataTransferObjectAttribute))
                               ?? throw new InvalidOperationException(
                                   $"{nameof(DataTransferObjectAttribute)} not found on type {nameof(Type)}.");

            return ((DataTransferObjectAttribute)dtoAttribute).DtoClassType;
        }
    }
}