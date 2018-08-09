using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Threading.Tasks;

namespace Oregon
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello World!\r\n");


            Console.Write("You are a banker\r\n");
            Console.Write("You have 400 dollars\r\n");

            UpdateService updateService = new UpdateService();

            var game = new Game();
            var wagon = new Wagon();

            wagon.Components.Add(new Player());



            InputManager.Init(updateService);


            updateService.GameObjects.Add(game);
            updateService.GameObjects.Add(wagon);
            updateService.Init();


            while (InputManager.CurrentKey.Key != ConsoleKey.Q)
            {
                Console.SetCursorPosition(0, 0);
                updateService.Update();
            }


        }
    }


   

    public class Game : GameObject
    {
       

        private object _options { get; set; }


    }

    public class Wagon : GameObject
    {
        private int _distanceTraveled;

        public int DistanceTraveled { get { return this._distanceTraveled; } }
        public bool HasOxen { get; set; }
        public bool IsOkay { get; set; }
        public bool StartTravel { get; set; } = false;

        public void Start()
        {
            this.HasOxen = true;
            this.IsOkay = true;
        }
        public void Update()
        {
            if (this.StartTravel)
            {
                this.Travel();
            }
        }

        public void OnKeyPress()
        {
            if (this.Input.KeyInfo.Key == ConsoleKey.Spacebar)
            {
                this.StartTravel = !this.StartTravel;
               
            }
        }

        private void Travel()
        {
            if (this.HasOxen && this.IsOkay)
            {
                this._distanceTraveled++;
            }
            //some how factor in the number of oxen also weather and terrain. and health of family and weight of wagon.
            Console.SetCursorPosition(1, 40);
            Console.Write($"Miles Traveled {this._distanceTraveled}");
        }
    }

    public class Player : GameObject
    {
        public double PlayerHealth = 100;
      
        public void Start()
        {
            Console.SetCursorPosition(1, 5);
            Console.Write("Initialize Player");

        }

        public void Update()
        {
            Console.SetCursorPosition(1, 15);
            Console.Write("I'm a playa");
        }

        public void OnKeyPress()
        {
            Console.SetCursorPosition(1, 20);
            Console.Write($"HEALTH: {this.PlayerHealth-=0.001}");         
        }

     
    }


    

}

