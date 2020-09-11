using System;

namespace Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes
{

    /// <summary>
    /// Marks corresponding DTO class of this domain class.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class)]
    public class DataTransferObjectAttribute : System.Attribute
    {
        public Type DtoClassType { get; }

        public DataTransferObjectAttribute(Type dtoClassType)
        {
            DtoClassType = dtoClassType;
        }
    }
}