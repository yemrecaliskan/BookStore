using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {

        public UpdateAuthorCommandModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public int AuthorId { get; set; }

        public UpdateAuthorCommand( BookStoreDbContext context )
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if ( author == null )
                throw new InvalidOperationException("Yazar bulunamadı!");

            author.Name = String.IsNullOrEmpty(Model.Name.Trim()) ? author.Name : Model.Name;
            author.Surname = String.IsNullOrEmpty(Model.Surname.Trim()) ? author.Surname : Model.Surname;
            author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;
            _context.SaveChanges();
        }
    }

    public class UpdateAuthorCommandModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}