using Isteyap.Core.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Domain.Entities
{
    public class EmailConfirmationToken : BasicEntityBase
    {
        public Guid UserID { get; set; }
        public User User { get; set; }
        public string TokenHash { get; set; }
        public DateTime ExpiredDate { get; set; }
        /// <summary>
        /// Email doğrulanma tarihi
        /// </summary>
        public DateTime UserAt { get; set; }
    }
}
