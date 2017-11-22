using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulation_project2
{
    class Want
    {
        int act;
        int time;
        public Want(int a)
        {
            Random rnd = new Random();
            act = a;
            switch(act)
            {
                case 1:
                    time = rnd.Next(10, 20);
                    break;
                case 2:
                    time = rnd.Next(15, 30);
                    break;
                case 3:
                    time = rnd.Next(5, 15);
                    break;
            }
        }
    }
}
