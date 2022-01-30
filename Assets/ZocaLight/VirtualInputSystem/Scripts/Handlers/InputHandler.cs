using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.VirtualInputSystem.Handlers
{
    /// <summary>
    /// Represents an abstract virtual input handler.
    /// </summary>
    public abstract class InputHandler
    {
        public string Name
        {
            get { return _name; }
        }
        
        //static List<VirtualInputHandler> handlers = new List<VirtualInputHandler>();



        string _name;

        /// <summary>
        /// Create and try to register itself.
        /// </summary>
        /// <param name="name"></param>
        protected InputHandler(string name)
        {
            _name = name;
            Debug.Log("Creating new virtual input handler:" + _name);

            // Try register handle
            VirtualInput.RegisterHandler(this);

         
           
            
        }



    }

}
