namespace Drone
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Random rand = new Random();

            List<Drone> drones = new List<Drone>();

            drones.Add(new Drone(5, 5, 50, 2, "Drone", false));
            drones.Add(new Drone(5, 15, 50, 5, "HyperDrone", false));

            
            do
            {
                Thread.Sleep(100);
                Console.Clear();

                foreach (var drone in drones)
                {

                    drone.Draw();
                    if(rand.Next(1,10) == 1)
                    {
                        
                    }
                    else
                    {
                        drone.Move();
                    }

                }

            } while (drones[0].Dead != true && drones[1].Dead != true);

        }
        
    }
}
