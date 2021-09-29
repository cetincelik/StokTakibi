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
    public class MarkaManager: IMarkaService
    {
        private IMarkaDal _markaDal;

        public MarkaManager(IMarkaDal markaDal)
        {
            _markaDal = markaDal;
        }

        public List<Markalar> GetAllMarkalar()
        {
            return _markaDal.GetList();
        }

        public Markalar GetMarkaById(int id)
        {
            return _markaDal.Get(p => p.ID == id);
        }

        public void CreateMarka(Markalar marka)
        {
            marka.AktifMi = true;
            marka.SilindiMi = false;
            _markaDal.Add(marka);
        }

        public void UpdateMarka(Markalar marka)
        {
            marka.AktifMi = true;
            marka.SilindiMi = false;
            _markaDal.Update(marka);
        }

        public void DeleteMarka(Markalar marka)
        {
            _markaDal.Delete(marka);
        }

        public void SilindiMarka(Markalar marka)
        {

            var k = _markaDal.Get(x => x.ID == marka.ID);
            k.SilindiMi = true;
            _markaDal.Update(k);

        }

        public void AktifMiMarka(Markalar marka)
        {
            var k = _markaDal.Get(x => x.ID == marka.ID);
            if (k.AktifMi == true)
            {
                k.AktifMi = false;
            }
            else
            {
                k.AktifMi = true;
            }
            _markaDal.Update(k);
        }
    }
}
