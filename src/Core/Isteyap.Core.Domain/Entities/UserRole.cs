using Isteyap.Core.Domain.Entities.Base;
using Isteyap.Core.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Domain.Entities
{
    public class UserRole : BasicEntityBase
    {
        public IsteyapUserRoleEnum Role { get; set; }
        public long UserID { get; set; }
        public User User { get; set; }
    }
}
