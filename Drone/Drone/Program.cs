namespace Drone
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Drone drone = new Drone(5, 5, 50, 2, "Drone");

            do
            {
                if (drone.battery > 0)
                {
                    drone.battery -= 2;
                    drone.x += 2;
                    Console.SetCursorPosition(drone.x, drone.y);
                    AffichageDeDrone();
                    Thread.Sleep(100);
                    Console.Clear();
                }
                if(drone.battery == 0)
                {
                    Console.SetCursorPosition(drone.x, drone.y);
                    AffichageDeMort();
                }


            } while (drone.battery > 0);
        }
        
    }
}
