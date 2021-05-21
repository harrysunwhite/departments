using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace departments.Models
{
    public class PhongBanSearchModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Page  { get; set; }
    }
}
