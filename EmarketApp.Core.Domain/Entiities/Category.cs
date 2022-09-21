using EmarketApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmarketApp.Core.Domain.Entiities
{
    public class Category : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }


        //Navigation Property - List w' all anuncios
        public ICollection<Anuncio> Anuncios { get; set; }

    }
}
