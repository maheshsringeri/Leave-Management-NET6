using AutoMapper;
using Leave_Management_NET6.Data;
using Leave_Management_NET6.Models;

namespace Leave_Management_NET6.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
        }
    }
}
