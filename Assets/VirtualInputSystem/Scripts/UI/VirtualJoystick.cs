using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zoca.Handlers;

namespace Zoca.UI
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
        float radius = 200; // The movement range

        [SerializeField]
        [Range(0,1)]
        float resetSpeed = 1f; // How fast you want the stick to reset on pointer up

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
                stick.anchoredPosition = Vector2.MoveTowards(stick.anchoredPosition, Vector2.zero, resetSpeed * 10000f * Time.deltaTime);

                UpdateAxisValue();
             
            }
        }

        void UpdateAxisValue()
        {
            // Set value
            float t = (stick.anchoredPosition.x / radius + 1f) / 2f;
            horizontalHandler.SetValue(Mathf.Lerp(-1f, 1f, t));
            t = (stick.anchoredPosition.y / radius + 1f) / 2f;
            verticalHandler.SetValue(Mathf.Lerp(-1f, 1f, t));
        }
        #endregion

        #region event handlers
        public void OnDrag(PointerEventData eventData)
        {
           
            stick.anchoredPosition += eventData.delta;
            stick.anchoredPosition = Vector2.ClampMagnitude(stick.anchoredPosition, radius);

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
