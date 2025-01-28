using AutoMapper;
using TaskManager.Core.DTOS;
using TaskManager.Core.Entities;
using TaskManager.Core.Enums;

namespace TaskManager.Application.Profiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskEntity, TaskDto>()
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State.ToString()));

        CreateMap<TaskDto, TaskEntity>()
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => Enum.Parse<TaskState>(src.State)));

        CreateMap<CreateTaskDto, TaskEntity>();
        CreateMap<UpdateTaskDto, TaskEntity>()
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => Enum.Parse<TaskState>(src.State)));
    }
}
