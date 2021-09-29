using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiCore.Entities.Abstract;
using StokTakibiEntities.Abstract;

namespace StokTakibiEntities.Concrete
{
    public class Markalar : IEntity, IAktifSilindiDurumu
    {
        [Key]
        public int ID { get; set; }

        //[Required(ErrorMessage = "Kategori alanı boş geçilemez.")]
        ////int? neden mi soru işareti, webui katmanında  ilgili view'de DropDownList için reguired ile mesaj döndürcez eğer bunu yapmazsan mesajı null olarak döndürüyor.
        //public int? UrunID { get; set; }

        [Required(ErrorMessage = "Marka adı alanı boş geçilemez.")]
        public string MarkaAdi { get; set; }


        public string Aciklama { get; set; }
        public bool AktifMi { get; set; }
        public bool SilindiMi { get; set; }

        //[ForeignKey("UrunID")]
        //public virtual Urunler Urunler { get; set; }
        ////public virtual StokTakipKategori Kategori { get; set; }

    }
}
