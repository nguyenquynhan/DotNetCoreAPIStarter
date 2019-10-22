using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace NetCoreTodoApi
{
    public class AutoMapperWrapper : IAutoMapperWrapper
    {
        private readonly IMapper _mapper;
        public AutoMapperWrapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IConfigurationProvider ConfigurationProvider
        {
            get
            {
                return _mapper.ConfigurationProvider;
            }
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }

        public List<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return source.Select(Map<TSource, TDestination>).ToList();
        }

        public void MapIntoCollection<TSource, TDestination>(ICollection<TDestination> destination, IEnumerable<TSource> source)
        {
            foreach (TSource item in source)
            {
                destination.Add(Map<TSource, TDestination>(item));
            }
        }
    }
}