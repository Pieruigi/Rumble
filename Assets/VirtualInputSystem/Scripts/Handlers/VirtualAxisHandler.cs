using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.Handlers
{
    /// <summary>
    /// Represent a virtual input axis, useful to implement analogic joystick axis.
    /// </summary>
    public class VirtualAxisHandler: VirtualInputHandler
    {
        // Represents the axis value ranging from -1 to 1
        float value = 0;
        

        public VirtualAxisHandler(string name): base(name)
        {
           
        }

        /// <summary>
        /// Call this from the UI in order to update value
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(float value)
        {
            this.value = Mathf.Clamp(value, -1, 1);
        }

        /// <summary>
        /// Call this in some controller to check axis value ( ex. in the player controller to
        /// move your character ).
        /// </summary>
        /// <returns></returns>
        public float GetValue()
        {
            return value;
        }

      
    }

}
