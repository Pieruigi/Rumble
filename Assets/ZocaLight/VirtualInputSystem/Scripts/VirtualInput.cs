using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zoca.VirtualInputSystem.Data;
using Zoca.VirtualInputSystem.Handlers;

namespace Zoca.VirtualInputSystem
{
    /// <summary>
    /// An hub containing all the virtual input handles.
    /// You can register a new handle or unregister an existing one or get existing axis to
    /// check input value.
    /// </summary>
    public class VirtualInput
    {
        #region private
        static List<InputHandler> handlers = new List<InputHandler>();

        static AxisHandler FindAxis(string name)
        {
            return (AxisHandler)handlers.Find(h => h.GetType() == typeof(AxisHandler) && h.Name.Equals(name));
        }

        static ButtonHandler FindButton(string name)
        {
            return (ButtonHandler)handlers.Find(h => h.GetType() == typeof(ButtonHandler) && h.Name.Equals(name));
        }

        static TapHandler FindTap(string name)
        {
            return (TapHandler)handlers.Find(h => h.GetType() == typeof(TapHandler) && h.Name.Equals(name));
        }

        static SwipeHandler FindSwipe(string name)
        {
            return (SwipeHandler)handlers.Find(h => h.GetType() == typeof(SwipeHandler) && h.Name.Equals(name));
        }
        #endregion

        #region public methods
        /// <summary>
        /// Register a new virtual input handle
        /// </summary>
        /// <param name="handler">The name of the handler to be registred.</param>
        public static void RegisterHandler(InputHandler handler)
        {
            if(handlers.Exists(h=>h.Name.Equals(handler.Name)))
                throw new System.Exception("Virtual input " + handler.Name + " already registred.");

            handlers.Add(handler);
        }

        /// <summary>
        /// Unregister an existing virtual input handle
        /// </summary>
        /// <param name="handler">The name of the handler to be unregistred.</param>
        public static void UnregisterHandler(InputHandler handler)
        {
            handlers.Remove(handler);
        }

        /// <summary>
        /// Returns true if an handler with the given name is registred.
        /// </summary>
        /// <param name="name">Check if an handler is already registred.</param>
        /// <returns>True if the handle is already registred, otherwise false.</returns>
        public static bool IsHandlerRegistred(string name)
        {
            return handlers.Exists(h => h.Name.Equals(name));
        }

        /// <summary>
        /// Returns a handler by a given name.
        /// </summary>
        /// <param name="name">The name of the handler you are looking for.</param>
        /// <returns>The input handler if exists, otherwise null.</returns>
        public static InputHandler GetHandler(string name)
        {
            return handlers.Find(h => h.Name.Equals(name));
        }

        /// <summary>
        /// Returns the virtual axis value if exists, otherwise an exception is thrown.
        /// </summary>
        /// <param name="name">The name of the axis to be checked.</param>
        /// <returns>The axis value tanging from -1 to 1</returns>
        public static float GetAxis(string name)
        {
            return  FindAxis(name).Value;
            
        }

        /// <summary>
        /// Returns the virtual axis raw value if exists, otherwise an exception is thrown.
        /// </summary>
        /// <param name="name">The name of the axis to be checed.</param>
        /// <returns>The axis value rounded to -1 or 1 depending whether the value is negative or
        /// positive, otherwise 0.</returns>
        public static float GetAxisRaw(string name)
        {
            return FindAxis(name).ValueRaw;

        }

        /// <summary>
        /// Returns true when the button is pressed.
        /// </summary>
        /// <param name="name">The name of the button to be checked.</param>
        /// <returns>True when the button is pressed, otherwise false.</returns>
        public static bool GetButtonDown(string name)
        {
            return FindButton(name).State == (int)ButtonState.Down;
        }

        /// <summary>
        /// Returns true when the button is down.
        /// </summary>
        /// <param name="name">The name of the button to be checked.</param>
        /// <returns>True if the button is down, otherwise false.</returns>
        public static bool GetButton(string name)
        {
            return FindButton(name).State == (int)ButtonState.KeepDown;
        }

        /// <summary>
        /// Returns true when the button is released.
        /// </summary>
        /// <param name="name">The name of the button to be checked.</param>
        /// <returns>True if the button is released, otherwise false.</returns>
        public static bool GetButtonUp(string name)
        {
            return FindButton(name).State == (int)ButtonState.Up;
        }

        /// <summary>
        /// Return true when the player taps the screen.
        /// Check out the TapData class for more info.
        /// </summary>
        /// <param name="data">A class holding info about the tap just performed.</param>
        /// <returns>True if the player tapped the screen, otherwise false.</returns>
        public static bool GetTap(out TapData data)
        {
            return FindTap(TapHandler.DefaultName).GetTap(out data);
            
        }

        /// <summary>
        /// Returns true while the player is swiping the screen.
        /// Check out the SwipeData class for more info.
        /// </summary>
        /// <param name="data">A class holding info about the swipe the player is performing.</param>
        /// <returns>True is the player is swiping the screen, otherwise false.</returns>
        public static bool GetSwipe(out SwipeData data)
        {
            return FindSwipe(SwipeHandler.DefaultName).GetSwipe(out data);

        }
        #endregion

    }

}
