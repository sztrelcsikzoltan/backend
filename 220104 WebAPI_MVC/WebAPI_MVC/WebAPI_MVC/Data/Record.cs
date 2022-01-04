using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_MVC.Data
{
    public class Record
    {
        public int Id { get; set; }

        public Record()
        { 
        }

        public Record(int id)
        {
            this.Id = id;
        }
    }
}
