using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRukes.GuestValidationRules
{
    public class UpdateGuestValidator:AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {


            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim Alanı Boş geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir Alanı Boş geçilemez");

            RuleFor(x => x.Name).MinimumLength(2).WithMessage("İsim Alanı en az 2 karakter olcak");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Soyisim Alanı en az 2 karakter olcak");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Şehir Alanı en az 3 karakter olcak");

            RuleFor(x => x.Name).MaximumLength(20).WithMessage("İsim Alanı en fazla 20 karakter olcak");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Soyisim Alanı en fazla 30 karakter olcak");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("Şehir Alanı en fazla 20 karakter olcak");

        }
    }
}
