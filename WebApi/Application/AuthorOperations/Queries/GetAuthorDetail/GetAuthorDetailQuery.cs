using AutoMapper;
using System;
using System.Linq;
using WebApi.DBOperations;

namespace BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailQuery( IBookStoreDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAuthorDetailQueryModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if ( author == null )
                throw new InvalidOperationException("Author not found!");

            GetAuthorDetailQueryModel returnObj = _mapper.Map<GetAuthorDetailQueryModel>(author);
            return returnObj;
        }
    }

    public class GetAuthorDetailQueryModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}