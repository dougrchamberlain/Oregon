using System;
using System.Collections.Generic;
using System.Linq;

namespace Oregon
{
    class Program
    {

        
        static void Main(string[] args)
        {


#region ConsoleInit
            Console.SetWindowSize(100, 32);
            Console.SetBufferSize(100, 32);

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            Console.Clear();
#endregion

            GameObject GameContext = new GameObject("World");

            GameContext.AddComponent<Wagon>();
            GameContext.AddComponent<Weather>();


            InputManager.Init();


            while (InputManager.CurrentKey.Key != ConsoleKey.Q)
            {
                UpdateService.Update();
  
 
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

