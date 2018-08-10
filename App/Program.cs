using System;


namespace Oregon
{

    class Program
    {
        public ScreenBuffer screen = new ScreenBuffer();

        static void Main(string[] args)
        {            
            var game = new Game();
            var wagon = new Wagon();

           
            
            InputManager.Init();


            UpdateService.GameObjects.Add(game);
            UpdateService.GameObjects.Add(wagon);
            UpdateService.GameObjects.Add(new Player());

            UpdateService.Init();


            while (InputManager.CurrentKey.Key != ConsoleKey.Q)
            {
                UpdateService.Update();
            }


        }
    }


}

