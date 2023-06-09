using DevFreela.Application.Commands.CreateProjectComment;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommentCommandValidator : AbstractValidator<CreateProjectCommentCommand>
    {
        public CreateProjectCommentCommandValidator()
        {
            RuleFor(p => p.Content)
               .MaximumLength(255)
               .WithMessage("Conteúdo deve conter no máximo 255 caracteres");
        }
    }
}
