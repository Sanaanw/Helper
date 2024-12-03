using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.Entities
{
    public class Students
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GroupID { get; set; }
        public Groups group { get; set; }
        public override string ToString()
        {
            return Name + group.Name;
        }
    }
}
