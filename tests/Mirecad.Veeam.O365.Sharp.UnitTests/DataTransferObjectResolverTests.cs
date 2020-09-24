using System.Reflection;
using FluentAssertions;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Xunit;

namespace Mirecad.Veeam.O365.Sharp.UnitTests
{
    public class DataTransferObjectResolverTests
    {
        private IDataTransferObjectResolver _resolver;

        private class ClassA
        {
            
        }

        [DataTransferObject(typeof(ClassA))]
        private class ClassB
        {
            
        }

        [DataTransferObject(typeof(ClassB))]
        private class ClassC<T>
        {

        }

        [DataTransferObject(typeof(ClassC<>))]
        private class ClassD<T>
        {

        }

        public DataTransferObjectResolverTests()
        {
            _resolver = new DataTransferObjectResolver();
        }

        [Fact]
        public void CanFindClassesWithDataTransferObjectAttribute()
        {
            var typesWithDtoAttribute =
                _resolver.GetTypesWithDataTransferObjectAttribute(Assembly.GetExecutingAssembly());

            typesWithDtoAttribute.Should()
                .Contain(new[] {typeof(ClassC<>), typeof(ClassB)})
                .And.NotContain(typeof(ClassA));
        }

        [Fact]
        public void CanFindSingleDataTransferObject()
        {
            var dtoType = _resolver.GetDataTransferObject(typeof(ClassC<>));

            dtoType.Should().Be(typeof(ClassB));
        }

        [Fact]
        public void CanFindRecursiveDtoObject()
        {
            var dtoType = _resolver.GetDataTransferObjectRecursive(typeof(ClassD<ClassB>));

            dtoType.Should().Be(typeof(ClassC<ClassA>));
        }

    }
}