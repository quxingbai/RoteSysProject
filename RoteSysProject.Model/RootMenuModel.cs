using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoteSysProject.Model
{
    public class RootMenuModel
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public int ParentID { get; set; }
        public String Link { get; set; }
    }
}
