using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.VirtualInputSystem.Data
{
    public class SwipeData
    {
        #region properties
        public float AverageSpeed
        {
            get { return totalDistance / duration; }
        }

        public float Speed
        {
            get { return delta.magnitude / Time.deltaTime; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public float Duration
        {
            get { return duration; }
        }

        public Vector2 Delta
        {
            get { return delta; }
        }

        public float Distance
        {
            get { return totalDistance; }
        }

        #endregion

        #region private fields
        Vector2 position;
        Vector2 delta;
        

        float totalDistance = 0;
        float duration;
        #endregion

        #region public methods

        public void Update(Vector2 position)
        {
            delta = position - this.position;
            this.position = position;
            totalDistance += delta.magnitude;
            duration += Time.deltaTime;
        }

        public void Reset()
        {
            delta = Vector2.zero;
            totalDistance = 0;
            duration = 0;
        }

        
        #endregion
    }
}
