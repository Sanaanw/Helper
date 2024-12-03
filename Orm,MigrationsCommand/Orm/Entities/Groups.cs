using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.Entities
{
    public class Groups
    {
        public int ID { get; set; }
        public string Name { get; set; }
        List<Students> Students { get; set; }
    }
}
