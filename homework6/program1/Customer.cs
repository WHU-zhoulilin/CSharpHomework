using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    [Serializable]
    public class Customer
    {
        static private uint id = 1;
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
        public Customer()
        {

        }
        public Customer(string name)
        {
            this.name = name;
            this.Id = id;
            id++;
        }
    }
}
