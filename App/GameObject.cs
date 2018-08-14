using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Oregon
{
    public class GameObject
    {
        static private List<GameObject> GlobalObjectList = new List<GameObject>();
        private readonly List<Component> Components = new List<Component>();

        public string Name { get; set; }
        public SortedSet<String> Tags { get; set; }

        public GameObject()
        {
            this.Initialize();
        }
        public GameObject(String Name)
        {
            this.Name = String.IsNullOrEmpty(Name) ? this.GetHashCode().ToString() : Name;
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
               return  g.Name == this.Name;
            });

            if (duplicate)
            {
                throw new Exception($"Name {this.Name} already exists");
            }

            GlobalObjectList.Add(this);
        }




        public void OnKeyPressEvent(InputManager.KeyPressEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("foo");
            this.Components.ForEach((c) =>
{
    var type = c.GetType();
    MethodInfo methodInfo = type.GetMethod("OnKeyPress");
    methodInfo?.Invoke(c, null);
});
        }

        private void OnUpdateEvent()
        {
            GameObject.GlobalObjectList.ForEach((g) => System.Diagnostics.Debug.WriteLine(g.Name));
            this.Components.ForEach((c) =>
{
    var type = c.GetType();
    MethodInfo methodInfo = type.GetMethod("Update");
    methodInfo?.Invoke(c, null);
});
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

        public void Update()
        {
            System.Diagnostics.Debug.WriteLine("foo");
        }

        public List<T> GetComponents<T>() where T : Component
        {
            return this.Components.Where((c) =>
            {
                return c.GetType() == typeof(T);
            }).Select(s => (T)s).ToList();
        }

    }

    public class Component
    {

    }
}


