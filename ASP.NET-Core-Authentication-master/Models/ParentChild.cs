using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class ParentChild
    {
        public int ID { get; set; }
        public int MembersID { get; set; }
        public Members? Members { get; set; }
        public int ChildID { get; set; }
        public Child? Child { get; set; }
    }
}
