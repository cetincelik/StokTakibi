using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiBusiness.Abstract;
using StokTakibiDataAccess.Abstract;
using StokTakibiEntities.Concrete;

namespace StokTakibiBusiness.Concrete
{
    public class KullaniciRolManager: IKullaniciRolService
    {
        private IKullaniciRolDal _kullaniciRolDal;

        public KullaniciRolManager(IKullaniciRolDal kullaniciRolDal)
        {
            _kullaniciRolDal = kullaniciRolDal;
        }

        public List<KullaniciRolleri> GetAllKullaniciRolleri()
        {
            return _kullaniciRolDal.GetList();
        }

        public KullaniciRolleri GetKullaniciRolById(int id)
        {
            return _kullaniciRolDal.Get(x => x.ID == id);
        }

        public void CreateKullaniciRol(KullaniciRolleri kullaniciRolleri)
        {
            _kullaniciRolDal.Add(kullaniciRolleri);
        }

        public void UpdateKullaniciRol(KullaniciRolleri kullaniciRolleri)
        {
            _kullaniciRolDal.Update(kullaniciRolleri);
        }

        public void DeleteKullaniciRol(KullaniciRolleri kullaniciRolleri)
        {
            _kullaniciRolDal.Delete(kullaniciRolleri);
        }

        public void SilindiKullaniciRol(KullaniciRolleri kullaniciRolleri)
        {
            throw new NotImplementedException();
        }

        public void AktifMiKullaniciRol(KullaniciRolleri kullaniciRolleri)
        {
            throw new NotImplementedException();
        }
    }
}
