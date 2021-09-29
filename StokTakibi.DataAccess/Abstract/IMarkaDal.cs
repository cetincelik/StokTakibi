using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiCore.DataAccess.Abstract;
using StokTakibiEntities.Concrete;

namespace StokTakibiDataAccess.Abstract
{
    public interface IMarkaDal: IEntityRepository<Markalar>
    {
    }
}
