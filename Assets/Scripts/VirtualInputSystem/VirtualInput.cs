using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zoca.Handlers;

namespace Zoca
{
    public class VirtualInput
    {
        static List<VirtualInputHandler> handlers = new List<VirtualInputHandler>();

        public static void RegisterHandler(VirtualInputHandler handler)
        {
            if(handlers.Exists(h=>h.Name.Equals(handler.Name)))
                throw new System.Exception("Virtual input " + handler.Name + " already exists.");

            handlers.Add(handler);
        }

        public static void UnregisterHandler(VirtualInputHandler handler)
        {
            handlers.Remove(handler);
        }

        public static VirtualAxisHandler GetAxis(string name)
        {
            VirtualAxisHandler ret = (VirtualAxisHandler)handlers.Find(h => h.GetType()==typeof(VirtualAxisHandler) && h.Name.Equals(name));
            return ret;
        }
    }

}
