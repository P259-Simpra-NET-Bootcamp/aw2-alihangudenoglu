using AutoMapper;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Staff,StaffModel>().ReverseMap();
            CreateMap<Staff,StaffAddressModel>().ReverseMap();
        }
    }
}
