using FluentValidation;
using RealEstateManager.Application.Common;
using RealEstateManager.Application.Propertys.Dto;

namespace RealEstateManager.Application.Propertys.Validations
{
    public class PropertyRequestValidator : AbstractValidator<PropertyRequestDto>
    {
        public PropertyRequestValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("El campo 'Name' es obligatorio.");
            RuleFor(x => x.Details).NotEmpty().WithMessage("El campo 'detalis' es obligatorio.");
            RuleFor(x => x.CodeInternal).NotEmpty().WithMessage("El campo 'detalis' es obligatorio.");
            RuleFor(x => x.City).NotEmpty().WithMessage("El campo 'City' es obligatorio.");
            RuleFor(x => x.Country).NotEmpty().WithMessage("El campo 'Country' es obligatorio.");
            RuleFor(x => x.Price).NotNull().WithMessage("El campo 'Country' no puede ser nulo.");
            // Agregar regla de validación para Status
            RuleFor(x => x.Status)
                .Must(statusName =>
                {
                    // Valida que ele estado enviado sea valido
                    var productStatus = Enum.IsDefined(typeof(PropertysStatusEnum), statusName);
                    return productStatus;
                })
                .WithMessage("El campo 'Status' no es válido.");
        }
    }
}
