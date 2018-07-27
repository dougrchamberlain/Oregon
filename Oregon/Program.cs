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


    public class InputManager
    {
        private static Task InputWatcherTask;
        public static event KeyPressEventHandler KeyPressEvent;

        public delegate void KeyPressEventHandler(KeyPressEventArgs e);

        public class KeyPressEventArgs : EventArgs
        {
            public ConsoleKeyInfo KeyInfo { get; set;}
        }

        public static ConsoleKeyInfo CurrentKey;
        private static UpdateService updateService;

        public static void Init(UpdateService updateService)
        {
            InputManager.updateService = updateService;
            InputWatcherTask = new Task(new Action(() =>
            {
                while(true){
                    if (Console.KeyAvailable)
                    {
                        KeyPressEvent?.Invoke(new KeyPressEventArgs() { KeyInfo = Console.ReadKey(true) });
                    }
                   
                }

            }));

            InputWatcherTask.Start();
        }



        public ConsoleKeyInfo KeyInfo { get { return CurrentKey; } }


    }

    public class UpdateService
    {
        public List<GameObject> GameObjects = new List<GameObject>();
        public static event UpdateEventHandler UpdateEvent;
        public delegate void UpdateEventHandler();


        public void Init()
        {
            GameObjects.ForEach((item) =>
            {
                Type thisType = item.GetType();
                MethodInfo invokable = thisType.GetMethod("Start");
                invokable?.Invoke(item, null);
            });

        }

        public void Update()
        {
            UpdateEvent.Invoke();
            


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


    public abstract class GameObject 
    {

        public InputManager Input = new InputManager();

     

        public GameObject()
        {
            UpdateService.UpdateEvent += this.OnUpdateEvent;
            InputManager.KeyPressEvent += this.OnKeyPressEvent;
            Console.Write(this.Input.KeyInfo.Key);
        }
        public readonly List<GameObject> Components = new List<GameObject>();

        private void OnUpdateEvent()
        {
            Type thisType = this.GetType();
            MethodInfo invokable = thisType.GetMethod("Update");
            invokable?.Invoke(this, null);
        }


        private void OnKeyPressEvent(InputManager.KeyPressEventArgs e)
        {
            InputManager.CurrentKey = e.KeyInfo;
            
                Type thisType = this.GetType();
                MethodInfo invokable = thisType.GetMethod("OnKeyPress");
                invokable?.Invoke(this, null);
            InputManager.CurrentKey = new ConsoleKeyInfo();
        }
    }

}

