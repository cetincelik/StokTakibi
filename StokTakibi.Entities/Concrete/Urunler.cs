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
    public class Urunler : IEntity,IAktifSilindiDurumu
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Kategori alanı boş geçilemez.")]
        public int? KategoriID { get; set; }

        [Required(ErrorMessage = "Marka alanı boş geçilemez.")]
        public int? MarkaID { get; set; }

        [Required(ErrorMessage = "Birim alanı boş geçilemez.")]
        public int? BirimID { get; set; }

        [Required(ErrorMessage = "Ürün adı boş geçilemez.")]
        public string UrunAdi { get; set; }

        [Required(ErrorMessage = "Bankod nosu boş geçilemez.")]
        public string BankodNo { get; set; }



        [Required(ErrorMessage = "Alış fiyatı boş geçilemez.")]
        public decimal? AlisFiyati { get; set; }

        [Required(ErrorMessage = "Satiş Fiyatı boş geçilemez.")]
        public decimal SatisFiyati { get; set; }

        [Required(ErrorMessage = "Miktarı boş geçilemez.")]
        public decimal? Miktari { get; set; }
        [Range(0,100,ErrorMessage = "0-100 arası rakam girilemez")]
        [Required(ErrorMessage = "KDV oranı boş geçilemez.")]
        public int? KDV { get; set; }




        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Tarih alanı boş geçilemez.")]
        public DateTime Tarih { get; set; }
        public  string Aciklama { get; set; }
        public bool AktifMi { get; set; }
        public bool SilindiMi { get; set; }

        [ForeignKey("KategoriID")]
        public virtual Kategoriler Kategoriler { get; set; }
       
        [ForeignKey("MarkaID")]
        public virtual Markalar Markalar { get; set; }
        
        [ForeignKey("BirimID")]
        public virtual Birimler Birimler { get; set; }

    }
}
