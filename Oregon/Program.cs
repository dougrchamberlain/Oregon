using System;
using System.Collections.Generic;
using System.Dynamic;
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

            ConsoleKeyInfo key;

            var game = new Game();

            game.Start();
            var input = new InputManager();


            game.Update();

        }
    }


    public class InputManager
    {
        private readonly Task InputWatcherTask;

        public event KeyPressEventHandler KeyPressEvent;

        public delegate void KeyPressEventHandler(object sender, EventArgs e);

        public class KeyPressEventArgs : EventArgs
        {
            public ConsoleKeyInfo KeyInfo { get; set;}
        }

        public InputManager()
        {            
            this.InputWatcherTask = new Task(new Action(() =>
            {
                 while (true) {
                    OnKeyPressEvent(new KeyPressEventArgs() { KeyInfo = Console.ReadKey(true) });
                 };
                //this.InputWatcherTask.Start();
            }));

            this.InputWatcherTask.Start();
        }

        protected virtual void OnKeyPressEvent(KeyPressEventArgs e)
        {
            KeyPressEvent?.Invoke(this, e);
            Console.WriteLine(e.KeyInfo.Key);
        }
 

    }

    class Game : IGameObject
    {
        public InputManager InputManager = new InputManager();

        private object _options { get; set; }

        private readonly List<IGameObject> Components = new List<IGameObject>();
        public void Start()
        {
            InputManager.KeyPressEvent += this.OnKeyPress;
            this.Components.Add(new Wagon());

            this.Components.ForEach((IGameObject item) =>
            {
                item.Start();
            });
        }


        public void OnKeyPress(object sender, EventArgs e)
        {
            Console.WriteLine("event");
        }

        public void Update()
        {

            foreach (var item in Components)
            {
                item.Update();
            }

            this.Update();
        }
    }

    public class Wagon : IGameObject
    {
        private int _distanceTraveled;

        public int DistanceTraveled { get { return this._distanceTraveled; } }
        public bool HasOxen { get; set; }
        public bool IsOkay { get; set; }

        public void Start()
        {
            this.HasOxen = true;
            this.IsOkay = true;
        }
        public void Update()
        {
            if (this.HasOxen && this.IsOkay)
            {
                this.Travel();
                System.Threading.Thread.Sleep(500);
            }
        }

        private void Travel()
        {
            //some how factor in the number of oxen also weather and terrain. and health of family and weight of wagon.
            this._distanceTraveled++;
            Console.Write($"\rMiles Traveled {this._distanceTraveled}");
        }
    }

    interface IGameObject
    {
        void Start();
        void Update();
    }

}

