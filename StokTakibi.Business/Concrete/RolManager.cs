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
    public class RolManager: IRolService
    {

        private IRolDal _rolDal;

        public RolManager(IRolDal rolDal)
        {
            _rolDal = rolDal;
        }

        public List<Roller> GetAllRoller()
        {
            return _rolDal.GetList();
        }

        public Roller GetRolById(int id)
        {
            return _rolDal.Get(x => x.ID == id);
        }

        public void CreateRol(Roller rol)
        {
            _rolDal.Add(rol);
        }

        public void UpdateRol(Roller rol)
        {
            _rolDal.Update(rol);
        }

        public void DeleteRol(Roller rol)
        {
            _rolDal.Delete(rol);
        }

        public void SilindiRol(Roller rol)
        {
            throw new NotImplementedException();
        }

        public void AktifMiRol(Roller rol)
        {
            throw new NotImplementedException();
        }
    }
}
