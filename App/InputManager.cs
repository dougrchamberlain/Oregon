using System;
using System.Threading.Tasks;

namespace Oregon
{
    public static class InputManager
    {
        private static Task InputWatcherTask;

        public static ConsoleKeyInfo CurrentKey;
        public static event KeyPressEventHandler KeyPressEvent;
        public delegate void KeyPressEventHandler(KeyPressEventArgs e);

        public static ConsoleKeyInfo KeyInfo { get { return CurrentKey; } }

        public class KeyPressEventArgs : EventArgs
        {
            public ConsoleKeyInfo KeyInfo { get; set; }
        }

        public static void Init()
        {

            InputWatcherTask = new Task(new Action(() =>
            {
                while (true)
                {

                    if (Console.KeyAvailable)
                    {

                        CurrentKey = Console.ReadKey(true);
                        System.Diagnostics.Debug.WriteLine($"key: {CurrentKey.Key}");
                        KeyPressEvent?.Invoke(new KeyPressEventArgs() { KeyInfo = CurrentKey });

                    }

                }

            }));

            InputWatcherTask.Start();
        }

    }

}

