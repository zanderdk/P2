using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt.models
{
    public class Permissions
    {
        public enum permissionTo { nothing=0, read=1, write=2 };
        public permissionTo member;
    }
}
