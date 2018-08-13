using System;

namespace Oregon
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Console.SetWindowSize(100, 32);
            Console.SetBufferSize(100, 32);

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            Console.Clear();

            GameObject GameContext = new GameObject("World");


            GameContext.AddComponent<Player>();
            //GameContext.AddComponent<Wagon>();
            //GameContext.AddComponent<Season>();

            //GameContext.BroadcastMessage("Start");
            InputManager.Init();

            while (InputManager.CurrentKey.Key != ConsoleKey.Q)
            {
                UpdateService.Update();
            }
        }
    }
}

