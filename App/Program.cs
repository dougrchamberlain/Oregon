using System;
using System.Collections.Generic;
using System.Linq;

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



            var player1 = GameContext.AddComponent<Player>();
            var player2 = GameContext.AddComponent<Player>();
            var player3 = GameContext.AddComponent<Player>();
            var player4 = GameContext.AddComponent<Player>();

            player1.Name = "Doug";
            player2.Name = "Jamie";
            player3.Name = "Shanna";
            player4.Name = "Leanne";

            GameContext.AddComponent<Food>();
            GameContext.AddComponent<Event>();

            InputManager.Init();


            while (InputManager.CurrentKey.Key != ConsoleKey.Q)
            {
                UpdateService.Update();
                UpdateService.CurrentDate = UpdateService.CurrentDate.AddDays(1);
 
            }


        }

        public static List<string> GetAllEntities()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                 .Where(x => typeof(Behavior).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                 .Select(x => x.Name).ToList();
        }
    }
}

