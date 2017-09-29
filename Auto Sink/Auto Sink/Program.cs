using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Sink
{
    class City : IComparable
    {
        private String name;
        private int charge;
        private HashSet<String> highways;
        public City(String name, int charge)
        {
            this.name = name;
            this.charge = charge;
            this.highways = new HashSet<string>();
        }
        public void addNewWay(String name)
        {
            highways.Add(name);
        }

        public int CompareTo(object obj)
        {
            City other = (City)obj;
            if (this.charge > other.charge)
            {
                return 1;
            }else
            {
                return 0;
            }
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
