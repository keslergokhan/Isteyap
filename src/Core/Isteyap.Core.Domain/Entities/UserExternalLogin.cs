using Isteyap.Core.Domain.Entities.Base;
using Isteyap.Core.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Domain.Entities
{
    public class UserExternalLogin : BasicEntityBase
    {
        /// <summary>
        /// Harici kimlik sağlayıcısının türü.
        /// Örneğin Google, Facebook, Apple vb.
        /// </summary>
        public ExternalAuthProvider Provider { get; set; }

        /// <summary>
        /// Harici kimlik sağlayıcısının kullanıcıya verdiği benzersiz kullanıcı kimliği.
        /// </summary>
        public string ProviderUserId { get; set; }

        /// <summary>
        /// Harici hesabın bağlandığı kullanıcı.
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Harici hesabın bağlı olduğu kullanıcı.
        /// </summary>
        public User User { get; set; }
    }
}
