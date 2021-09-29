using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiEntities.Concrete;

namespace StokTakibiBusiness.Abstract
{
   public interface IKullaniciRolService
    {
        List<KullaniciRolleri> GetAllKullaniciRolleri();

        KullaniciRolleri GetKullaniciRolById(int id);

        void CreateKullaniciRol(KullaniciRolleri kullaniciRolleri);

        void UpdateKullaniciRol(KullaniciRolleri kullaniciRolleri);

        void DeleteKullaniciRol(KullaniciRolleri kullaniciRolleri);

        void SilindiKullaniciRol(KullaniciRolleri kullaniciRolleri);

        void AktifMiKullaniciRol(KullaniciRolleri kullaniciRolleri);
    }
}
