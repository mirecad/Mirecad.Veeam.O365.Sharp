 using System;
using System.Reflection;
using Autofac;
using AutoMapper;
using AutoMapper.Configuration;

namespace Mirecad.Veeam.O365.Sharp.Infrastructure
{
    internal sealed class Mapping
    {
        private static IMapper _mapper;
        private static readonly object Lock = new object();

        private Mapping()
        {
            //never used
        }

        public static IMapper Mapper
        {
            get
            {
                lock (Lock)
                {
                    if (_mapper == null)
                    {
                        throw new InvalidOperationException("Mapper was not yet created.");
                    }

                    return _mapper;
                }
            }
        }

        public static IMapper Create(IDataTransferObjectResolver dtoResolver, IContainer serviceContainer)
        {
            lock (Lock)
            {
                if (_mapper != null)
                {
                    throw new InvalidOperationException("Mapper was already created.");
                }

                var mappings = new MapperConfigurationExpression
                {
                    ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly,
                    ShouldMapField = f => true
                };
                mappings.ConstructServicesUsing(serviceContainer.Resolve);
                mappings.AddProfile(new DtoMappingProfile(dtoResolver));
                var config = new MapperConfiguration(mappings);
                var mapper = new Mapper(config);
                _mapper = mapper;
                return _mapper;
            }
        }
    }

    internal class DtoMappingProfile : Profile
    {
        /// <summary>
        /// Mappings between api response DTOs and domain objects.
        /// We use reflection based on class attribute to map them.
        /// </summary>
        /// <param name="dtoResolver"></param>
        public DtoMappingProfile(IDataTransferObjectResolver dtoResolver)
        {
            var domainObjects = dtoResolver
                .GetTypesWithDataTransferObjectAttribute(Assembly.GetExecutingAssembly());

            foreach (var domainObject in domainObjects)
            {
                var dtoType = dtoResolver.GetDataTransferObject(domainObject);
                CreateMap(dtoType, domainObject)
                    .ConstructUsingServiceLocator();
                CreateMap(domainObject, dtoType);
            }
        }
    }
}