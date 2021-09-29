using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiCore.Entities.Abstract;

namespace StokTakibiEntities.Concrete
{
    public class Roller:IEntity
    {
        [Key] 
        public int ID { get; set; }

        public string Rol { get; set; }
    }
}
