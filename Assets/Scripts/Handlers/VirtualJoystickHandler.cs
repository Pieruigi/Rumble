using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.Handlers
{
    public class VirtualJoystickHandler
    {
        float horizontalAxis;
        float verticalAxis;

        public VirtualJoystickHandler()
        {

        }

        public void SetHorizontalAxis(float value)
        {
            horizontalAxis = Mathf.Clamp(value, -1, 1);
        }

        public void SetVerticalAxis(float value)
        {
            verticalAxis = Mathf.Clamp(value, -1, 1);
        }

        public float GetVerticalAxis()
        {
            return verticalAxis;
        }

        public float GetHorizontalAxis()
        {
            return horizontalAxis;
        }
    }

}
