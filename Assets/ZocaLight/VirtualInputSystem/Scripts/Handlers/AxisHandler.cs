using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.VirtualInputSystem.Handlers
{
    /// <summary>
    /// Represent a virtual input axis, useful to implement analogic joystick axis.
    /// </summary>
    public class AxisHandler: InputHandler
    {
        public float Value
        {
            get { return value; }
        }

        public float ValueRaw
        {
            get { return value == 0 ? 0 : (value > 0 ? 1 : -1); }
        }

        // Represents the axis value ranging from -1 to 1
        float value = 0;
        

        public AxisHandler(string name): base(name)
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

       

      
    }

}
