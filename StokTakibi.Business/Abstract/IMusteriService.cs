using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiEntities.Concrete;

namespace StokTakibiBusiness.Abstract
{
    public interface IMusteriService
    {
        List<Musteriler> GetAllMusteriler();

        Musteriler GetMusteriById(int id);

        void CreateMusteri(Musteriler musteri);

        void UpdateMusteri(Musteriler musteri);

        void DeleteMusteri(Musteriler musteri);

        void SilindiMusteri(Musteriler musteri);

        void AktifMiMusteri(Musteriler musteri);
    }
}
