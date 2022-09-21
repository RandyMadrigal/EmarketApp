using EmarketApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmarketApp.Core.Domain.Entiities
{
   public class Anuncio : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public string ImgFile1 { get; set; }
        public string ImgFile2 { get; set; }
        public string ImgFile3 { get; set; }
        public string ImgFile4 { get; set; }


        #region Category
        //Foreign key
        public int CategoryId { get; set; }

        //Navigation Property
        public Category Category { get; set; }
        #endregion

        #region User
        //Foreign key
        public int UserId { get; set; }

        //Navigation Property
        public User User { get; set; }
        #endregion


        
    }
}
