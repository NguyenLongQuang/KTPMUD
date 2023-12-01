using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class LienHe
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string SoDT
        {
            get
            {
                var s = new Stack<int>();
                var v = Id;
                while (v != 0)
                {
                    s.Push(v % 1000);
                    v /= 1000;
                }

                var r = "0";

                while (s.Count > 0)
                {
                    r += string.Format("{0:000}", s.Pop()) + ' ';
                }
                return r;
            }
        }
    }

    internal class LienHeList : List<LienHe> 
    { 
        public LienHeList()
        {
            this.AddRange(new Provider().Select<LienHe>("SELECT * FROM LienHe"));
        }
    }
}
