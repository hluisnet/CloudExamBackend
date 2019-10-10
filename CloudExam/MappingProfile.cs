using AutoMapper;
using CloudExam.Models;
using CloudExam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
          
            this.CreateMap<ProductViewModel, Product>().ForMember(x => x.Id, opt => opt.Ignore());

        }
    }
}
