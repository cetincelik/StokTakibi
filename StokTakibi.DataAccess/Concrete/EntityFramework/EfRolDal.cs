using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiCore.DataAccess.Concrete.EntityFramework;
using StokTakibiDataAccess.Abstract;
using StokTakibiDataAccess.Concrete.EntityFramework.Contexts;
using StokTakibiEntities.Concrete;

namespace StokTakibiDataAccess.Concrete.EntityFramework
{
    public class EfRolDal: EfEntityRepositoryBase<Roller, StokTakibiContext>, IRolDal
    {
    }
}
