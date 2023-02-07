using FluentValidation;
using Schedule.API.V1.Dtos;

namespace Schedule.API.V1.Validations
{
    public class CreateScheduleValidatio : AbstractValidator<ScheduleDto>
    {
        public CreateScheduleValidatio()
        {
            RuleFor(s => s.Name).NotEmpty().NotNull().WithMessage("O campo nome é obrigatório {PropertyName}");
        }
    }
}
