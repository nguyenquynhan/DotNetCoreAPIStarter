using AutoMapper;
using System.Collections.Generic;

namespace NetCoreTodoApi
{
    public interface IAutoMapperWrapper
    {
        IConfigurationProvider ConfigurationProvider { get; }
        TDestination Map<TDestination>(object source);
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
        List<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source);
        void MapIntoCollection<TSource, TDestination>(ICollection<TDestination> destination, IEnumerable<TSource> source);
    }
}