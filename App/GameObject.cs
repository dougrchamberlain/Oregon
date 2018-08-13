using Oregon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Oregon.InputManager;

namespace Oregon { 



    public class GameObject
    {

        private readonly List<Component> Components = new List<Component>();

        public string Name { get; set; }


        public GameObject()
        {         
            UpdateService.UpdateEvent += OnUpdateEvent;

            InputManager.KeyPressEvent += OnKeyPressEvent;
        }

        public void OnKeyPressEvent(KeyPressEventArgs e)
        {
                                                System.Diagnostics.Debug.WriteLine("foo");
                         this.Components.ForEach((c) =>
            {                                
                var type = c.GetType();
                MethodInfo methodInfo = type.GetMethod("OnKeyPress");
                methodInfo?.Invoke(c,null);
            });
        }

        private void OnUpdateEvent()
        {

                        this.Components.ForEach((c) =>
            {                                
                var type = c.GetType();
                MethodInfo methodInfo = type.GetMethod("Update");
                methodInfo?.Invoke(c, null);
            });
        }

        public GameObject(String Name)
        {          
            this.Name = Name;
            UpdateService.UpdateEvent += OnUpdateEvent;
            InputManager.KeyPressEvent += OnKeyPressEvent;
        }

        public T AddComponent<T>() where T : Behavior
        {
            var component = Activator.CreateInstance<T>();

            this.Components.Add(component);
            component.gameObject = this;


            var type = component.GetType();
                MethodInfo methodInfo = type.GetMethod("Start");
                methodInfo?.Invoke(component, null);

            return component;

        }


    }

    public class Component
    {

    }
}


