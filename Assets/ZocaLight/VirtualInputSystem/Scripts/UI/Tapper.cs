using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zoca.VirtualInputSystem.Handlers;

namespace Zoca.VirtualInputSystem.UI
{
    public class Tapper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        #region private fields
        [SerializeField]
        [Tooltip("How much time you can keep your finger down before the tap action fail. " +
            "Set zero if you want to keep your finger down forever. Default: 0.5 sec.")]
        float tapTime = 0.5f;

        bool tapping = false;
        System.DateTime startTime;
        TapHandler handler;
        float elapsed = 0;

        #endregion

        #region private methods
        private void Awake()
        {
            // Create handler
            handler = new TapHandler();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (tapping)
            {
                if(elapsed > 0)
                {
                    elapsed -= Time.deltaTime;

                    if (elapsed <= 0)
                        tapping = false;
                }
                
            }

           
        }

        IEnumerator Reset()
        {
            yield return new WaitForEndOfFrame();

            tapping = false;
            handler.ResetTap();
        }
        #endregion

        #region event callbacks
        /// <summary>
        /// You have to tap, not to drag.
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            tapping = false;
            elapsed = 0;
            handler.ResetTap();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //throw new System.NotImplementedException();
            tapping = true;
            startTime = System.DateTime.UtcNow;
            elapsed = tapTime;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (tapping)
            {
                elapsed = 0;

                // Set the handler
                float duration = (float)(System.DateTime.UtcNow - startTime).TotalSeconds;
                handler.Update(eventData.position, duration);

                // Reset at the end of the frame
                StartCoroutine(Reset());
            }
        }

   
        #endregion
    }

}
