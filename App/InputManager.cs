using System;
using System.Threading.Tasks;

namespace Oregon
{
    public class InputManager
    {        
        private static UpdateService updateService;
        private static Task InputWatcherTask;

        public static ConsoleKeyInfo CurrentKey;
        public static event KeyPressEventHandler KeyPressEvent;
        public delegate void KeyPressEventHandler(KeyPressEventArgs e);
        
        public ConsoleKeyInfo KeyInfo { get { return CurrentKey; } }

        public class KeyPressEventArgs : EventArgs
        {
            public ConsoleKeyInfo KeyInfo { get; set;}
        }
    
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

    }

}

