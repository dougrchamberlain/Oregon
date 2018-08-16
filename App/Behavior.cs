using System;
using System.Reflection;

namespace Oregon
{
    public class Behavior : Component
    {
        private readonly bool isAwake;
        public GameObject gameObject;


        protected Behavior()
        {
           isAwake = false;
        }


    }


}