using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soy İsim alanı boş geçilemez.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir Bilgisi Giriniz.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az iki karakter veri giriniz.");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("En az üç karakter veri giriniz.");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("En fazla yirmi karakter veri giriniz.");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("En fazla otuz karakter veri giriniz.");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("En fazla yirmi karakter veri giriniz.");
        }
    }
}
