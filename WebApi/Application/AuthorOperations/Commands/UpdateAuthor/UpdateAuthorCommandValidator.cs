using FluentValidation;
using System;
namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {

            RuleFor(command => command.Model.Name).MinimumLength(3).When(author => author.Model.Name.Trim() != string.Empty); ;
            RuleFor(command => command.Model.Surname).MinimumLength(3).When(author => author.Model.Surname.Trim() != string.Empty);
            RuleFor(command => command.Model.BirthDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}