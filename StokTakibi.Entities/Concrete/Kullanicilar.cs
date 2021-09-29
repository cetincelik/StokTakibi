using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiCore.Entities.Abstract;

namespace StokTakibiEntities.Concrete
{
    public class Kullanicilar:IEntity
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı alanı boş geçilemez.")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")]
        public string Sifre { get; set; }
        

        public string Rol { get; set; }

        [Required(ErrorMessage = "Adı Soyadı alanı boş geçilemez.")]
        public string AdiSoyadi { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Telefon Numarası alanı boş geçilemez.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Uygun formatta telefon numarası giriniz.")]
        public string Telefon { get; set; }


        [Required(ErrorMessage = "Adres alanı boş geçilemez.")]
        public string Adres { get; set; }


        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",
            ErrorMessage = "Lütfen uygun formatta e-mail adresi giriniz.")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "E-mail alanı boş geçilemez.")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Tarih alanı boş geçilemez.")]
        public DateTime Tarih { get; set; }
        
    }
}
