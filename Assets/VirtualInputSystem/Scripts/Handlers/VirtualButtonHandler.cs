using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.VirtualInputSystem.Handlers
{
    public enum ButtonState { None, Down, KeepDown, Up }

    public class VirtualButtonHandler : VirtualInputHandler
    {
        
        public int State
        {
            get { return state; }
        }

        int state = (int)ButtonState.None;

        public VirtualButtonHandler(string name) : base(name) { }

        public void SetState(int state)
        {
            this.state = state;
        }

        public void Reset()
        {
            SetState(0);
        }

    }

}
