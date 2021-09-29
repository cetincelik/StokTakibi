using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiCore.Entities.Abstract;
using StokTakibiEntities.Abstract;

namespace StokTakibiEntities.Concrete
{
    public class Musteriler : IEntity,IAktifSilindiDurumu
    {
        [Key]
        public int ID { get; set; }
        public string AdiSoyadi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string Resim { get; set; }
        public DateTime KayitTarihi { get; set; }
        public float Puani { get; set; }
        public string Aciklama { get; set; }

        public bool AktifMi { get; set; }
        public bool SilindiMi { get; set; }
    }
}
