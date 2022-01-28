using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zoca.Handlers;

namespace Zoca.UI
{
    public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        #region private fields
        [SerializeField]
        string horizontalAxisName;

        [SerializeField]
        string verticalAxisName;

        [SerializeField]
        RectTransform joystick;

        [SerializeField]
        float radius = 200;

        [SerializeField]
        [Range(0,1)]
        float resetSpeed = 1f;

        // The handlers
        VirtualAxisHandler horizontalHandler;
        VirtualAxisHandler verticalHandler;

        // Center position
        Vector2 center;
        Vector2 position;
        bool isDown = false;
        

        #endregion

        #region private methods
        private void Awake()
        {
            // Create handlers
            horizontalHandler = new VirtualAxisHandler(horizontalAxisName);
            verticalHandler = new VirtualAxisHandler(verticalAxisName);

            // Keep center position
            center = joystick.anchoredPosition;
            position = center;
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
                Debug.Log("Reset");
                // Reset
                joystick.anchoredPosition = Vector2.MoveTowards(joystick.anchoredPosition, Vector2.zero, resetSpeed * 10000f * Time.deltaTime);
                float t = (joystick.anchoredPosition.x / radius + 1f) / 2f;
                horizontalHandler.SetValue(Mathf.Lerp(-1f, 1f, t));
                t = (joystick.anchoredPosition.y / radius + 1f) / 2f;
                verticalHandler.SetValue(Mathf.Lerp(-1f, 1f, t));
            }
        }

        
        #endregion

        #region event handlers
        public void OnDrag(PointerEventData eventData)
        {
            Debug.LogFormat("VirtualJoystick - On drag");
            Debug.LogFormat("VirtualJoystick - On drag, delta:"+ eventData.delta);

            joystick.anchoredPosition += eventData.delta;
            joystick.anchoredPosition = Vector2.ClampMagnitude(joystick.anchoredPosition, radius);

            // Set value
            float t = (joystick.anchoredPosition.x / radius + 1f) / 2f;
            horizontalHandler.SetValue(Mathf.Lerp(-1f, 1f, t));
            t = (joystick.anchoredPosition.y / radius + 1f) / 2f;
            verticalHandler.SetValue(Mathf.Lerp(-1f, 1f, t));

            Debug.LogFormat("Handler - GetValue() - x:{0}, y:{1}", horizontalHandler.GetValue(), verticalHandler.GetValue());
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.LogFormat("VirtualJoystick - On pointer down");
            isDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.LogFormat("VirtualJoystick - On pointer up");
            isDown = false;
        }

        #endregion
    }

}
