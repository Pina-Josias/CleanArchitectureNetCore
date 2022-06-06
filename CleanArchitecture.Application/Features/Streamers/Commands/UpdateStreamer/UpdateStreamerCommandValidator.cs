using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{0} No se permiten nulos");
            RuleFor(p => p.Url)
                .NotNull().WithMessage("{0} No se permiten nulos");
        }
    }
}
