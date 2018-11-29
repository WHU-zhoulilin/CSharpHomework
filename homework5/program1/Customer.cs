using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    
    public class Customer
    {
        static private uint id = 1;
        [Key]
        public uint Id
        {
            get;
            set;
        }
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                name = value;
            }
        }
        private string telephone;
        public string Telephone
        {
            get
            {
                return this.telephone;
            }
            
            set
            {
                this.telephone = value;
            }
        }
        public Customer()
        {

        }
        public Customer(string name,string T)
        {
            this.name = name;
            this.Id = id;
            id++;
            Telephone = T;
        }
    }
}
