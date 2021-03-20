using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaClone.Application.AutoMapper;

namespace InstaClone.WebAPI.Configuration
{
    public static class AutoMapperConfig
        //classe de extensão 
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //incompatible version
            //services.AddAutoMapper(typeof(DomainToViewModelMap), typeof(ViewModelToDomainMap));

            var mapperConfig = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile(new DomainToViewModelMap());
                mapper.AddProfile(new ViewModelToDomainMap());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
