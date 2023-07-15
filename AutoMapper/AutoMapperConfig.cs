using AutoMapper;
using KeyValuePairAssignment.Dto;

namespace KeyValuePairAssignment.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<KeyValueModel, KeyValueModel>();
            CreateMap<KeyValueModel, ReqPostValues>().ReverseMap();
        }
    }
}
