using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageHanlder
{
    public class T_Circle
    {
        public String ID {
            get;set;
        }
        public T_Circle() {
            ID = Guid.NewGuid().ToString();
        }
    }
}
