using System;
using System.Collections.Generic;
using System.Reflection;

namespace Oregon
{
    public sealed class UpdateService
    {
        public static event UpdateEventHandler UpdateEvent;
        public delegate void UpdateEventHandler();
        public static DateTime CurrentDate = new DateTime(1848,3,1);


        public static void Update()
        {
            ScreenBuffer.DrawScreen();
            UpdateEvent.Invoke();
            System.Threading.Thread.Sleep(350);
        }

    }

}

