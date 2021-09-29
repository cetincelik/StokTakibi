using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiEntities.Concrete;

namespace StokTakibiBusiness.Abstract
{
    public interface IRolService
    {
        List<Roller> GetAllRoller();

        Roller GetRolById(int id);

        void CreateRol(Roller rol);

        void UpdateRol(Roller rol);

        void DeleteRol(Roller rol);

        void SilindiRol(Roller rol);

        void AktifMiRol(Roller rol);
    }
}
