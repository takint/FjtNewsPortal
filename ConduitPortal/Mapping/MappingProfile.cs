using AutoMapper;
using FjtFramework.Cores;
using FjtFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConduitPortal.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var types = typeof(ICreateMapping).GetTypeInfo().Assembly.GetTypes();
            LoadEntityMappings(types);
        }

        private void LoadEntityMappings(IEnumerable<Type> types)
        {
            // Define mapping for base class
            CreateMap<BaseEntity, BaseViewModel>().ForMember(x => x.RowVersion, c => c.MapFrom(entity => ByteArrayConverter.ToString(entity.RowVersion)));
            CreateMap<BaseViewModel, BaseEntity>().ForMember(x => x.RowVersion, c => c.MapFrom(dto => ByteArrayConverter.FromString(dto.RowVersion)));

            var maps = (from t in types
                        where typeof(ICreateMapping).IsAssignableFrom(t)
                              && !t.GetTypeInfo().IsAbstract
                              && !t.GetTypeInfo().IsInterface
                        select (ICreateMapping)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMapping(this);
            }
        }
    }
}
