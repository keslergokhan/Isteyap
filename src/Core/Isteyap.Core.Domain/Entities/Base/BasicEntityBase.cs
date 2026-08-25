using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Domain.Entities.Base
{
    public abstract class BasicEntityBase
    {
        public long Id { get; set; }
        public EntityStateEnum State { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
