using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmarketApp.Core.Domain.Common
{
    //Informaciones generales que deben tener las entities
    public class AuditableBaseEntity
    {
        public virtual int Id { get; set; }
        public string Autor { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
