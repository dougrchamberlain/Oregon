using System;
using System.Collections.Generic;
using System.Reflection;

namespace Oregon
{
    public class UpdateService
    {
        public static List<GameObject> GameObjects = new List<GameObject>();
        public static event UpdateEventHandler UpdateEvent;
        public delegate void UpdateEventHandler();


        public static void Init()
        {
            Console.WindowWidth = 100;
            Console.WindowHeight = 50;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            Console.Clear();


            GameObjects.ForEach((item) =>
            {
                Type thisType = item.GetType();
                MethodInfo invokable = thisType.GetMethod("Start");
                invokable?.Invoke(item, null);
            });

            

        }

        public static void Update()
        {

            UpdateEvent.Invoke();

            //System.Threading.Thread.Sleep(2);

            ScreenBuffer.DrawScreen();
           
        }

    }

}

