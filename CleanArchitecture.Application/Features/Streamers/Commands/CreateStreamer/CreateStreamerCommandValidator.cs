using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{0} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("El {0} no puede exceder los 50 caracteres");

            RuleFor(p => p.Url)
                .NotEmpty();
        }
    }
}
