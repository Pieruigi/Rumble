using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Zoca.VirtualInputSystem.Handlers
{
    

    public class SwipeHandler : InputHandler
    {
        public const string DefaultName = "Swipe";

        

        bool swiping = false;
        Data.SwipeData data = new Data.SwipeData();

        public SwipeHandler() : base(DefaultName) { }

        public void Update(Vector2 position)
        {
            if (!swiping)
            {
                swiping = true;
                data.Reset(); // Just to be sure
                data.Update(position);
            }
            else
            {
                data.Update(position);
            }

        }

       
        public void ResetSwipe()
        {
            swiping = false;
            data.Reset();
        }

        public bool GetSwipe(out Data.SwipeData info)
        {
            info = this.data;
            return swiping;
        }
    }

}
