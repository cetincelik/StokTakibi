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
    public class Kategoriler : IEntity,IAktifSilindiDurumu
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Kategori adı alanı boş geçilemez.")]
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public bool AktifMi { get; set; }
        public bool SilindiMi { get; set; }
    }
}
