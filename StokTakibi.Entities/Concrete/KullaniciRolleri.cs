using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiCore.Entities.Abstract;

namespace StokTakibiEntities.Concrete
{
    public class KullaniciRolleri:IEntity
    {
        [Key]
        public int ID { get; set; }

        public int KullaniciID { get; set; }

        public int RolID { get; set; }
    }
}
