using AutoMapper;
using System;

namespace AuthServer.Service
{
    public static class ObjectMapper
    {
        //lazy loading only needing this func loading data
        private static readonly Lazy<IMapper> lazy = new(() =>
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<DtoMapper>(); });
            return config.CreateMapper();
        });

        public static IMapper Mapper { get; private set; } = lazy.Value;
    }
}