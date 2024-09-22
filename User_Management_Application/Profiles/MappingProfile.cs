using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using User_Management_Application.DTOs.Person;
using User_Management_Application.DTOs.Resume;
using User_Management_Domain;

namespace User_Management_Application.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Person, PersonDto>().ReverseMap();
			CreateMap<Resume, ResumeDto>().ReverseMap();
			CreateMap<CreatePersonDto, Person>().ReverseMap();
			CreateMap<UpdatePersonDto, Person>().ReverseMap();
			CreateMap<CreateResumeDto, Resume>().ReverseMap();
			CreateMap<UpdateResumeDto, Resume>().ReverseMap();
		}
	}
}
