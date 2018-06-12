using AutoMapper;
using MyColours.Website.Core.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductsMappings>();

            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}