using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StokTakibiBusiness.Abstract;
using StokTakibiDataAccess.Abstract;
using StokTakibiEntities.Concrete;

namespace StokTakibiBusiness.Concrete
{
    public class BirimManager: IBirimService
    {
        private IBirimDal _birimDal;

        public BirimManager(IBirimDal birimDal)
        {
            _birimDal = birimDal;
        }

        public List<Birimler> GetAllBirimler()
        {
            return _birimDal.GetList();
        }

        public Birimler GetBirimById(int id)
        {
            return _birimDal.Get(p => id == p.ID);
        }

        public void CreateBirim(Birimler birim)
        {
            birim.AktifMi = true;
            birim.SilindiMi = false;

            _birimDal.Add(birim);
        }

        public void UpdateBirim(Birimler birim)
        {
            birim.AktifMi = true;
            birim.SilindiMi = false;
            _birimDal.Update(birim);
        }

        public void DeleteBirim(Birimler birim)
        {
            _birimDal.Delete(birim);
        }

        public void SilindiMiBirim(Birimler birim)
        {
            var k = _birimDal.Get(x => x.ID == birim.ID);
            k.SilindiMi = true;
            _birimDal.Update(k);

        }

        public void AktifMiBirim(Birimler birim)
        {
            var k = _birimDal.Get(x => x.ID == birim.ID);
            if (k.AktifMi == true)
            {
                k.AktifMi = false;
            }
            else
            {
                k.AktifMi = true;
            }
            _birimDal.Update(k);
        }
    }
}
