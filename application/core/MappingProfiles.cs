using System;
using AutoMapper;
using domain;

namespace application.core;

public class MappingProfiles :Profile
{
    public MappingProfiles()
    {
        CreateMap<Activity, Activity>();
    }
}
