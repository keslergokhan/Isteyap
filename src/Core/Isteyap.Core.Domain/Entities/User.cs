using Isteyap.Core.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Domain.Entities
{
    public partial class User : BasicEntityBase
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
        /// Kullanıcının tam adı (FirstName ve LastName birleştirilmiş).
        /// Sadece okunur; veritabanına ayrı bir sütun olarak kaydedilmez.
        /// </summary>
        public string FullName => $"{FirstName} {LastName}".Trim();

        /// <summary>
        /// Kullanıcının e-posta adresi.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Arama/kıyaslama amaçlı normalize edilmiş e-posta (büyük/küçük harf duyarsız).
        /// </summary>
        public string NormalizedEmail { get; set; }

        /// <summary>
        /// E-posta doğrulama durumu.
        /// </summary>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// Kullanıcının telefon numarası.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Güvenli şekilde saklanan parola hash'i.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Kullanıcının en son oturum açma zamanı.
        /// </summary>
        public DateTime? LastLoginAt { get; set; }

        /// <summary>
        /// Kullanıcıya atanmış rollerin isimleri.
        /// Basitlik için string koleksiyonu; ihtiyaç halinde Role entity ile ilişki kurulabilir.
        /// </summary>
        
    }

    public partial class User
    {
        public ICollection<UserRole> Roles { get; set; }
        public ICollection<EmailConfirmationToken> EmailConfirmationToken { get; set; }
        public ICollection<UserExternalLogin> UserExternalLogin { get; set; }
    }
}
