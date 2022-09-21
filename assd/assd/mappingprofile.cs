using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assd
{
    public class mappingprofile:Profile
    {
        public mappingprofile()
        {
            CreateMap<StudentRegister, student>();
            CreateMap<RegFormDTO, regform>();
            CreateMap<regform, RegFormDTO>();

        }
    }
}
