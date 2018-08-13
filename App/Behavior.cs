using System;
using System.Reflection;

namespace Oregon
{
    public class Behavior : Component
    {
        public GameObject gameObject;
        public InputManager Input = new InputManager();


        protected Behavior()
        {

        }


    }


}