using System;


namespace Oregon
{

    class Program
    {        

        static void Main(string[] args)
        {            
            var game = new Game();
            var wagon = new Wagon();

           
            
            InputManager.Init();


            UpdateService.GameObjects.Add(game);
            UpdateService.GameObjects.Add(wagon);
            UpdateService.GameObjects.Add(new Player());

            UpdateService.Init();

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            Console.Clear();


            while (InputManager.CurrentKey.Key != ConsoleKey.Q)
            {
                UpdateService.Update();
            }


        }
    }


}

