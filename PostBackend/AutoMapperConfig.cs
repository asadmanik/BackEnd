
using AutoMapper;
using PostBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostBackend
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<Post, vmPost>()
                .ForMember(dst => dst.PostId, src => src.MapFrom(ol => ol.PostId))
                .ForMember(dst => dst.PostTitle, src => src.MapFrom(ol => ol.PostTitle))
                .ForMember(dst => dst.PostAddedBy, src => src.MapFrom(ol => ol.PostAddedBy))
                .ForMember(dst => dst.PostAddedBy, src => src.MapFrom(ol => ol.PostAddedBy));

            //CreateMap<Comment, vmComment>()
            //    .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => HttpContext.Current.User.Identity.GetUserId()));
        }
    }

    public class AutoMapperConfig
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClientMappingProfile>();
            });
            return config;
        }
    }
}