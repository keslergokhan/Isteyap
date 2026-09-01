using AutoMapper;
using Isteyap.Core.Application.Features;
using Isteyap.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<ConsumerRegisterCommand, User>();
        }
    }
}
