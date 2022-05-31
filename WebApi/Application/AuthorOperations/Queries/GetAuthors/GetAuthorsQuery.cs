using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorsQuery
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery( BookStoreDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetAuthorsQueryModel> Handle()
        {
            var authorList = _context.Authors.OrderBy(author => author.Id).ToList<Author>();
            List<GetAuthorsQueryModel> returnObj = _mapper.Map<List<GetAuthorsQueryModel>>(authorList);
            return returnObj;
        }

    }

    public class GetAuthorsQueryModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}