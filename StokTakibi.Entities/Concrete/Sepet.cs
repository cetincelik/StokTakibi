﻿using System;
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
    public class Sepet : IEntity,IAktifSilindiDurumu
    {
        [Key]
        public int ID { get; set; }
        public int? UrunID { get; set; }
        public int KullaniciID { get; set; }
        public decimal BirimFiyati { get; set; }
        public decimal Miktari { get; set; }
        public decimal ToplamFiyati { get; set; }
      
        public DateTime Tarih { get; set; }
        public DateTime Saat { get; set; }

        public bool AktifMi { get; set; }
        public bool SilindiMi { get; set; }

        [ForeignKey("KullaniciID")]
        public virtual Kullanicilar Kullanicilar { get; set; }

        [ForeignKey("UrunID")]
        public virtual Urunler Urunler { get; set; }

        
    }
}
