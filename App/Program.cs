using System;

namespace Oregon
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetBufferSize(100, 32);
            Console.SetWindowSize(100, 32);

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            Console.Clear();

            var game = new Game();
            var wagon = new Wagon();
            var player = new Player();
            var player2 = new Player();
            var Season = new Season();

            player.Components.Add(new Food());
            player2.Components.Add(new Food());

            InputManager.Init();

            UpdateService.GameObjects.Add(game);
            UpdateService.GameObjects.Add(wagon);
            UpdateService.GameObjects.Add(player);
            UpdateService.GameObjects.Add(Season);            
            UpdateService.Init();


            while (InputManager.CurrentKey.Key != ConsoleKey.Q)
            {
                UpdateService.Update();
            }
        }
    }
}

