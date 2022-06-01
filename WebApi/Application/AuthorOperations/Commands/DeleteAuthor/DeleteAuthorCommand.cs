using AutoMapper;
using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }


        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;

        public DeleteAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(author => author.Id == AuthorId);
            if (author == null)
                throw new InvalidOperationException("Yazar bulunamadı.");

            bool authorHasBooks = _context.Books.Any(book => book.Id == AuthorId);
            if (authorHasBooks)
                throw new InvalidOperationException("Bu yazarın kitapları bulunuyor. Önce kitapları silmelisin.");

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}