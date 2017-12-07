using AutoMapper;
using OnlineShop.Model.Models;
using OnlineShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            //Mapper.Map<Post, PostViewModel>(Post, PostViewModel);
            Mapper.Initialize(cfg => {
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                cfg.CreateMap<PostTag, PostTagViewModel>();
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
            });
        }
    }
}