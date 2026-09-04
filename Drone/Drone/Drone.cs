using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    internal class Drone
    {
        public int x , y;
        public int battery;
        public int speed;
        public string name;
        bool dead;

        public Drone (int x, int y, int battery, int speed, string name)
        {
            this.x = x;
            this.y = y;
            this.battery = battery;
            this.speed = speed;
            this.name = name;
            this.dead = false;
        }

        internal void Draw()
        {
            if (!this.dead)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("x-0-x");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-----");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        internal void Move()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow: y--; break;
            }
        }


    }
}
