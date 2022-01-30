using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zoca.VirtualInputSystem.Handlers;

namespace Zoca.VirtualInputSystem.UI
{
    public class VirtualButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region actions
        // Useful for example if you want to add some feedback when the button is pressed
        public UnityAction<VirtualButton> OnButtonDown;
        public UnityAction<VirtualButton> OnButtonUp;

        #endregion


        #region private fields
        [SerializeField]
        string buttonName; // The name of the button ( jump, attack, ecc )

        bool isDown = false;
       
        ButtonHandler handler;
        #endregion

        private void Awake()
        {
            handler = new ButtonHandler(buttonName);
            
            // Reset the handle 
            handler.Reset();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }

       
        IEnumerator CheckTheEndOfFrame(bool checkIsDown)
        {
            yield return new WaitForEndOfFrame();

            if (checkIsDown)
            {
                if(isDown)
                    handler.SetState((int)ButtonState.KeepDown);
            }
            else
            {
                if (!isDown)
                    handler.SetState((int)ButtonState.None);
            }
            
        }

        public void OnPointerDown(PointerEventData eventData)
        {
           
            isDown = true;
            handler.SetState((int)ButtonState.Down);
            StartCoroutine(CheckTheEndOfFrame(true));

            OnButtonDown?.Invoke(this);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isDown = false;
            handler.SetState((int)ButtonState.Up);
            StartCoroutine(CheckTheEndOfFrame(false));

            OnButtonUp?.Invoke(this);
        }
    }

}
