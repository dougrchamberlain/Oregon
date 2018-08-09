using System;
using System.Collections.Generic;
using System.Reflection;

namespace Oregon
{
   public abstract class GameObject 
    {
        public InputManager Input = new InputManager();
        public readonly List<GameObject> Components = new List<GameObject>();
  
        public GameObject()
        {
            UpdateService.UpdateEvent += this.OnUpdateEvent;
            InputManager.KeyPressEvent += this.OnKeyPressEvent;
            Console.Write(this.Input.KeyInfo.Key);
        }

        private void OnUpdateEvent()
        {
            Type thisType = this.GetType();
            MethodInfo invokable = thisType.GetMethod("Update");
            invokable?.Invoke(this, null);
        }

        private void OnKeyPressEvent(InputManager.KeyPressEventArgs e)
        {
            InputManager.CurrentKey = e.KeyInfo;
            
                Type thisType = this.GetType();
                MethodInfo invokable = thisType.GetMethod("OnKeyPress");
                invokable?.Invoke(this, null);
            InputManager.CurrentKey = new ConsoleKeyInfo();
        }
    }

}

