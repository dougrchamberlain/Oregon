using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Oregon
{
   public abstract class GameObject 
    {
        public InputManager Input = new InputManager();
        public readonly List<GameObject> Components = new List<GameObject>();

        protected static T GetComponent<T>()
        {
            T foundObject = UpdateService.GameObjects.Where((g) =>
            {
                var thisType = g.GetType();
                return thisType == typeof(T);
            }).Select(s => (T)Convert.ChangeType(s,typeof(T)) ).FirstOrDefault();

            if (foundObject == null)
            {
                foundObject = Activator.CreateInstance<T>();
            }

            UpdateService.Add(foundObject);
            return foundObject;
        }

        public string Name { get; set; }

        public GameObject()
        {
            UpdateService.UpdateEvent += this.OnUpdateEvent;
            InputManager.KeyPressEvent += this.OnKeyPressEvent;
        }

        public GameObject(String Name)
            :base()
        {
            this.Name = Name;

            Components.ForEach((item) =>
            {
                Type thisType = item.GetType();
                MethodInfo invokable = thisType.GetMethod("Start");
                invokable?.Invoke(item, null);
            });

        }

        public static IEnumerable<GameObject> GetComponentsByName(String Name)
        {
            
            return UpdateService.GameObjects.Where((g) =>
            {
                return g.Name == Name;
            }).ToList();
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

