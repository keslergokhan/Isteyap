using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Features
{
    public class ConsumerRegisterCommandValidator : AbstractValidator<ConsumerRegisterCommand>
    {
        public ConsumerRegisterCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim boş olamaz.")
                .MaximumLength(100).WithMessage("İsim en fazla 100 karakter olabilir.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim boş olamaz.")
                .MaximumLength(100).WithMessage("Soyisim en fazla 100 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
                .MaximumLength(256).WithMessage("E-posta en fazla 256 karakter olabilir.");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(50).WithMessage("Telefon numarası en fazla 50 karakter olabilir.")
                .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Parola boş olamaz.")
                .MinimumLength(8).WithMessage("Parola en az 8 karakter olmalıdır.")
                .MaximumLength(128).WithMessage("Parola en fazla 128 karakter olabilir.")
                .Matches("[A-Z]").WithMessage("Parola en az bir büyük harf içermelidir.")
                .Matches("[a-z]").WithMessage("Parola en az bir küçük harf içermelidir.")
                .Matches("\\d").WithMessage("Parola en az bir rakam içermelidir.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Parola tekrarı boş olamaz.")
                .Equal(x => x.Password)
                .WithMessage("Parolalar eşleşmiyor.");
        }
    }
}
