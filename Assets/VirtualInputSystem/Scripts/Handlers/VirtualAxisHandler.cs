using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.Handlers
{
    public class VirtualAxisHandler: VirtualInputHandler
    {
        
        float value = 0;
        

        public VirtualAxisHandler(string name): base(name)
        {
           
        }

        public void SetValue(float value)
        {
            this.value = Mathf.Clamp(value, -1, 1);
        }

        
        public float GetValue()
        {
            return value;
        }

      
    }

}
