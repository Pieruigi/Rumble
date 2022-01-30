using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.VirtualInputSystem.Handlers
{
    /// <summary>
    /// Tap input handle.
    /// Tap normally comes across the all screen so you don't really need to have multiple
    /// action names; for this reason we always set a default tap name for this type of input.
    /// The tap action is called on pointer up toghether with the tap position.
    /// </summary>
    public class TapHandler: InputHandler
    {
        public const string DefaultName = "Tap";

        bool taping = false;
        //Vector2 position; // The position in screen coordinates

        Data.TapData data = new Data.TapData();

        public TapHandler():base(DefaultName) { }
        
        
        public void Update(Vector2 position, float duration)
        {
            taping = true;
            data.Update(position, duration);
        }

        public void ResetTap()
        {
            taping = false;
        }

        public bool GetTap(out Data.TapData data)
        {
            data = this.data;
            return taping;
        }
    }

}
