using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiEntities.Concrete;

namespace StokTakibiBusiness.Abstract
{
    public interface IBirimService
    {
        List<Birimler> GetAllBirimler();

        Birimler GetBirimById(int id);

        void CreateBirim(Birimler birim);

        void UpdateBirim(Birimler birim);

        void DeleteBirim(Birimler birim);

        void SilindiMiBirim(Birimler birim);

        void AktifMiBirim(Birimler birim);
    }
}
