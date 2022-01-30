using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.VirtualInputSystem.Handlers
{
    // All the possible states a button can be in
    public enum ButtonState { None, Down, KeepDown, Up }

    public class ButtonHandler : InputHandler
    {
        #region properties
        public int State
        {
            get { return state; }
        }
        #endregion

        #region private fields
        int state = (int)ButtonState.None;
        #endregion

        /// <summary>
        /// The constructor simply calls the parent methods passing the button name.
        /// </summary>
        /// <param name="name"></param>
        public ButtonHandler(string name) : base(name) { }

        #region public methods
        /// <summary>
        /// Set the button state
        /// </summary>
        /// <param name="state"></param>
        public void SetState(int state)
        {
            this.state = state;
        }

        /// <summary>
        /// Set the button state to ButtonState.None.
        /// </summary>
        public void Reset()
        {
            SetState(0);
        }
        #endregion

    }

}
