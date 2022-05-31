using AutoMapper;
using BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorsQuery;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name ));
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
            CreateMap<Author, GetAuthorsQueryModel>();
            CreateMap<Author, GetAuthorDetailQueryModel>();
        }
    }
}