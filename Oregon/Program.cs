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
            Console.WriteLine("Hello World!");


            Console.WriteLine("You are a banker");
            Console.WriteLine("You have 400 dollars");


            var game = new Game();
            var wagon = new Wagon();
            

            InputManager.Init();


            UpdateService.GameObjects.Add(game);
            UpdateService.GameObjects.Add(wagon);

            UpdateService.Init();


            while (InputManager.CurrentKey.Key != ConsoleKey.Q)
            {
                UpdateService.Update();
                //Console.CursorTop = 5;
                //Console.WriteLine("\rdooing game stuff {0}", InputManager.CurrentKey.Key);
            }

            //game.Start();

            //game.Update();

            //Console.Read();

        }
    }


    public class InputManager
    {
        private static Task InputWatcherTask;
        private static event KeyPressEventHandler KeyPressEvent;

        private delegate void KeyPressEventHandler(KeyPressEventArgs e);

        protected class KeyPressEventArgs : EventArgs
        {
            public ConsoleKeyInfo KeyInfo { get; set;}
        }

        public static ConsoleKeyInfo CurrentKey;

        public static void Init()
        {
            KeyPressEvent += OnKeyPressEvent;
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

        private static void OnKeyPressEvent(KeyPressEventArgs e)
        {
            CurrentKey = e.KeyInfo;
            UpdateService.GameObjects.ForEach((item) =>
            {
                Type thisType = item.GetType();
                MethodInfo invokable = thisType.GetMethod("OnKeyPress");
                invokable?.Invoke(item, null);
            });

            CurrentKey = new ConsoleKeyInfo();
        }

        public ConsoleKeyInfo KeyInfo { get { return CurrentKey; } }


    }

    public static class UpdateService
    {
        public static List<GameObject> GameObjects = new List<GameObject>();


        public static void Init()
        {
            GameObjects.ForEach((item) =>
            {
                Type thisType = item.GetType();
                MethodInfo invokable = thisType.GetMethod("Start");
                invokable?.Invoke(item, null);
            });

        }

        public static void Update()
        {
            GameObjects.ForEach((item) =>
            {
                Type thisType = item.GetType();
                MethodInfo invokable = thisType.GetMethod("Update");
                invokable?.Invoke(item, null);
            });


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
                Console.WriteLine("toggling traveling");
               
            }
        }

        private void Travel()
        {
            if (this.HasOxen && this.IsOkay)
            {
                this._distanceTraveled++;
            }
            //some how factor in the number of oxen also weather and terrain. and health of family and weight of wagon.
            Console.Write($"\rMiles Traveled {this._distanceTraveled}");
        }
    }


    public abstract class GameObject 
    {

        public InputManager Input = new InputManager();

        public GameObject()
        {
            Console.WriteLine(this.Input.KeyInfo.Key);
        }
        public readonly List<GameObject> Components = new List<GameObject>();


    }

}

