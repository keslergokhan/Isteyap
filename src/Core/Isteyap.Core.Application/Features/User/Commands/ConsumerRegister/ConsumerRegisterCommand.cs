using FluentValidation;
using Isteyap.Core.Application.Results;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Features
{
    public class ConsumerRegisterCommand : IRequest<IResultControl>
    {
        /// <summary>
        /// Kullanıcının ilk adı.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Kullanıcının soyadı.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Kullanıcının e-posta adresi.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Kullanıcının telefon numarası (opsiyonel).
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Düz metin parola (sunucu tarafında hashlenip saklanmalı).
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Parola doğrulama alanı.
        /// </summary>
        public string ConfirmPassword { get; set; }
    }
    
}
