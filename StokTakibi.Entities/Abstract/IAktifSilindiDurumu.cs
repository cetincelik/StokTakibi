using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakibiEntities.Abstract
{
    public interface IAktifSilindiDurumu
    {
        public bool AktifMi { get; set; }
        public bool SilindiMi { get; set; }
    }
}
