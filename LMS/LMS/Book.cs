using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class Book
    {
        public int id;
        public string title;
        public string authorNname;
        public Book(int id, string title, string authorNname)
        {
            this.id = id;
            this.title = title;
            this.authorNname = authorNname;
        }
    }
}
