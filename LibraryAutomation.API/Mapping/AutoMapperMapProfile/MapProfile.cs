using AutoMapper;
using LibraryAutomation.API.DTOs;
using LibraryAutomation.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAutomation.API.Mapping.AutoMapperMapProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AuthorListDto>();
            CreateMap<Author, AuthorUpdateDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, BookUpdateDto>().ReverseMap();
            CreateMap<BorrowBook, BorrowBookDto>().ReverseMap();
            CreateMap<BorrowBook, BorrowBookUpdateDto>().ReverseMap();
        }
    }
}
