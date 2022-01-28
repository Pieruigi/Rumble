using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zoca.VirtualInputSystem.Handlers;

namespace Zoca.VirtualInputSystem.UI
{
    /// <summary>
    /// A virtual joystick UI implementation
    /// </summary>
    public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        #region private fields
        [SerializeField]
        string horizontalAxisName; // Name of the horizontal axis

        [SerializeField]
        string verticalAxisName; // Name of the vertical axis

        [SerializeField]
        RectTransform stick; // The stick

        [SerializeField]
        float moveRange = 200; // The movement range

        [SerializeField]
        float resetTime = 0f; // The time it will take to reset ( 0 means immediate )

        // The handlers
        VirtualAxisHandler horizontalHandler;
        VirtualAxisHandler verticalHandler;

        
        bool isDown = false;
       

        #endregion

        #region private methods
        private void Awake()
        {
            // Create handlers
            horizontalHandler = new VirtualAxisHandler(horizontalAxisName);
            verticalHandler = new VirtualAxisHandler(verticalAxisName);
   

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(!isDown)
            {
                // Reset the stick
                if(resetTime > 0)
                {
                    stick.anchoredPosition = Vector2.MoveTowards(stick.anchoredPosition, Vector2.zero, 1000f / resetTime * Time.deltaTime);
                }
                else
                {
                    stick.anchoredPosition = Vector2.zero;
                }

                UpdateAxisValue();
             
            }
        }

        void UpdateAxisValue()
        {
            // Set value
            float t = (stick.anchoredPosition.x / moveRange + 1f) / 2f;
            horizontalHandler.SetValue(Mathf.Lerp(-1f, 1f, t));
            t = (stick.anchoredPosition.y / moveRange + 1f) / 2f;
            verticalHandler.SetValue(Mathf.Lerp(-1f, 1f, t));
        }
        #endregion

        #region event handlers
        public void OnDrag(PointerEventData eventData)
        {
           
            stick.anchoredPosition += eventData.delta;
            stick.anchoredPosition = Vector2.ClampMagnitude(stick.anchoredPosition, moveRange);

            UpdateAxisValue();

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isDown = false;
        }

        #endregion
    }

}
