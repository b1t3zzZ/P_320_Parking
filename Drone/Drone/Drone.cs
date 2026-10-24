using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    internal class Drone
    {
        public int X { get; set; }
        public int Y {get; set;}
        public int Battery { get; set;}
        public int Speed { get; set;}
        public string Name {  get; set;}
        public bool Dead { get; set; }

        public Drone (int x, int y, int battery, int speed, string name, bool Dead)
        {
            this.X = x;
            this.Y = y;
            this.Battery = battery;
            this.Speed = speed;
            this.Name = name;
            this.Dead = Dead;
        }
        internal void Draw()
        {
            if (Battery > 0)
            {
                Console.SetCursorPosition(this.X, this.Y);
                Console.WriteLine("x-0-x");
            }
            if (X == 50)
            {
                Console.SetCursorPosition(this.X, this.Y);
                this.Dead = true;
                Console.WriteLine("-----");
            }
        }
        internal void Move()
        {
            if(Battery != 0)
            {
                X += Speed;
                Battery -= Speed;
            }
            
        }
    }
}
