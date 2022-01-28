using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zoca.Handlers;

namespace Zoca
{
    /// <summary>
    /// An hub containing all the virtual input handles.
    /// You can register a new handle or unregister an existing one or get existing axis to
    /// check input value.
    /// </summary>
    public class VirtualInput
    {
        static List<VirtualInputHandler> handlers = new List<VirtualInputHandler>();

        /// <summary>
        /// Register a new virtual input handle
        /// </summary>
        /// <param name="handler"></param>
        public static void RegisterHandler(VirtualInputHandler handler)
        {
            if(handlers.Exists(h=>h.Name.Equals(handler.Name)))
                throw new System.Exception("Virtual input " + handler.Name + " already exists.");

            handlers.Add(handler);
        }

        /// <summary>
        /// Unregister an existing virtual input handle
        /// </summary>
        /// <param name="handler"></param>
        public static void UnregisterHandler(VirtualInputHandler handler)
        {
            handlers.Remove(handler);
        }

        /// <summary>
        /// Rturns the virtual axis with the given name if exists, otherwise null.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static VirtualAxisHandler GetAxis(string name)
        {
            VirtualAxisHandler ret = (VirtualAxisHandler)handlers.Find(h => h.GetType()==typeof(VirtualAxisHandler) && h.Name.Equals(name));
            return ret;
        }
    }

}
