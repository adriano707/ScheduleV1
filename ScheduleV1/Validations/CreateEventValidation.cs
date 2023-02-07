using FluentValidation;
using Schedule.API.V1.Dtos;

namespace Schedule.API.V1.Validations
{
    public class CreateEventValidation : AbstractValidator<CreateEventDto>
    {
        public CreateEventValidation()
        {
            RuleFor(e => e.Name).NotEmpty().NotNull().WithMessage("O campo nome é obrigatório {PropertyName}");
            RuleFor(e => e.Description).NotEmpty().NotNull().WithMessage("O campo descrição é obrigatório {PropertyName}");
            RuleFor(e => e.Date).NotEmpty().NotNull().WithMessage("O campo data é obrigatório {PropertyName}");
            RuleFor(e => e.Locality).NotEmpty().NotNull().WithMessage("O campo Localidade é obrigatório {PropertyName}");
            RuleFor(e => e.EventType).IsInEnum().NotNull().WithMessage("O campo tipo do evento é obrigatório {PropertyName}");
            RuleFor(e => e.Participants).NotEmpty().NotNull().WithMessage("O campo participantes é obrigatório {PropertyName}");
        }
    }
}
