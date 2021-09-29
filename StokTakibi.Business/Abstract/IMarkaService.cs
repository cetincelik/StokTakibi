using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiEntities.Concrete;

namespace StokTakibiBusiness.Abstract
{
    public interface IMarkaService
    {
        List<Markalar> GetAllMarkalar();

        Markalar GetMarkaById(int id);

        void CreateMarka(Markalar marka);

        void UpdateMarka(Markalar marka);

        void DeleteMarka(Markalar marka);

        void SilindiMarka(Markalar marka);

        void AktifMiMarka(Markalar marka);
    }
}
