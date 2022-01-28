using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.Handlers
{
    public abstract class VirtualInputHandler
    {
        public string Name
        {
            get { return _name; }
        }
        
        //static List<VirtualInputHandler> handlers = new List<VirtualInputHandler>();



        string _name;

        
        protected VirtualInputHandler(string name)
        {
            _name = name;
            Debug.Log("Create new handler:" + _name);

            VirtualInput.RegisterHandler(this);

            //// Check if exists
            //Debug.Log("Handlers.Count:" + handlers.Count);
            //VirtualInputHandler handler = handlers.Find(h => h._name.Equals(name));

            //if (handler != null)
            //{
            //    Debug.LogErrorFormat("Handler.Name={0} already registred.", name);
            //    return;
            //}
            
            //handlers.Add(this);
            
        }


        //public static VirtualInputHandler GetHandler(string name)
        //{
        //    return handlers.Find(h => h._name.Equals(name));
        //}



    }

}
