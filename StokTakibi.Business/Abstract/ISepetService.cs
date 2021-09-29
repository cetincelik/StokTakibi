using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiEntities.Concrete;

namespace StokTakibiBusiness.Abstract
{
    public interface ISepetService
    {
        List<Sepet> GetAllSepetler();

        Sepet GetSepetById(int id);
        List<Sepet> KullanıcıSepeti(int id);

        List<Sepet> KullaniciIDGoreSepetGetir(int kulaniciID);
        Sepet KullaniciIDGoreUrunuSepeteGetir(int kulaniciID, int urun_ID);

        void CreateSepet(Sepet sepet);

        void UpdateSepet(Sepet sepet);

        void MiktarSifirla(Sepet sepet);

        void DeleteSepet(Sepet sepet);

        void SilindiMiSepet(Sepet sepet);

        void AktifMiSepet(Sepet sepet);
    }
}
