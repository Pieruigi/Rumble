using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.VirtualInputSystem.Data
{
    public class TapData
    {
        /// <summary>
        /// The position of your finger in screen coords.
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
        }

        /// <summary>
        /// How long you kept your finger down.
        /// </summary>
        public float Duration
        {
            get { return duration; }
        }

        Vector2 position;
        float duration;

        public void Update(Vector2 position, float duration)
        {
            this.position = position;
            this.duration = duration;
        }
    }
}
