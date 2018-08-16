using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;

namespace Oregon
{
    public class GameObject
    {
        static private Type[] ComponentTypes = { };
        static private List<GameObject> GlobalObjectList = new List<GameObject>();
        private readonly BlockingCollection<Component> Components = new BlockingCollection<Component>();

        public string Name { get; set; }
        public SortedSet<String> Tags { get; set; } = new SortedSet<string>();

        public GameObject()
        {
            this.Initialize();
        }
        public GameObject(String Name)
        {
            this.Name = String.IsNullOrEmpty(Name) ? this.GetHashCode().ToString() : Name;
            this.Initialize();
        }

        public GameObject(String Name, params Type[] types)
        {
            this.Name = String.IsNullOrEmpty(Name) ? this.GetHashCode().ToString() : Name;
            ComponentTypes = types;
            this.Initialize();
        }


        public static GameObject Find(String Name)
        {
            return GlobalObjectList.Single((g) => g.Name == Name);
        }

        private void Initialize()
        {
            UpdateService.UpdateEvent += OnUpdateEvent;

            InputManager.KeyPressEvent += OnKeyPressEvent;

            var duplicate = GlobalObjectList.Any((g) =>
            {
                return g.Name == this.Name;
            });

            if (duplicate)
            {
                throw new Exception($"Name {this.Name} already exists");
            }

            GlobalObjectList.Add(this);

            foreach (var t in ComponentTypes)
            {
                MethodInfo method = GetType().GetMethod("AddComponent", BindingFlags.Public | BindingFlags.Instance)
                                         .MakeGenericMethod(new Type[] { t });
                method.Invoke(this, null);
            }

            foreach (var c in this.Components)
            {
                var type = c.GetType();
                MethodInfo methodInfo = type.GetMethod("Awake");
                methodInfo?.Invoke(c, null);
            };


            foreach (var c in this.Components)
            {
                var type = c.GetType();
                MethodInfo methodInfo = type.GetMethod("Start");
                methodInfo?.Invoke(c, null);
            };
           


        }




        public void OnKeyPressEvent(InputManager.KeyPressEventArgs e)
        {

            foreach (var c in this.Components)
            {
                var type = c.GetType();
                MethodInfo methodInfo = type.GetMethod("OnKeyPress");
                methodInfo?.Invoke(c, null);
            };
        }

        private void OnUpdateEvent()
        {
            foreach (var c in this.Components)
            {
                var type = c.GetType();
                MethodInfo methodInfo = type.GetMethod("Update");
                methodInfo?.Invoke(c, null);
            };
        }


        public T AddComponent<T>() where T : Behavior
        {
            var component = Activator.CreateInstance<T>();

            this.Components.TryAdd(component,-1);
            component.gameObject = this;


            var type = component.GetType();
            MethodInfo methodInfo = type.GetMethod("Start");
            methodInfo?.Invoke(component, null);
            return component;

        }

        public List<T> GetComponents<T>() where T : Component
        {
            return this.Components.Where((c) =>
            {
                return c.GetType() == typeof(T);
            }).Select(s => (T)s).ToList();
        }

        public T GetComponent<T>() where T : Behavior
        {
            T found = this.Components.Where((c) =>
            {
                return c.GetType() == typeof(T);
            }).Select(s => (T)s).FirstOrDefault();
            
            return found;
        }

    }

    public class Component
    {

    }
}


