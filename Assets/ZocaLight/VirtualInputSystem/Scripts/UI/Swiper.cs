using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zoca.VirtualInputSystem.Handlers;

namespace Zoca.VirtualInputSystem.UI
{
    public class Swiper : MonoBehaviour, IEndDragHandler, IDragHandler
    {

        bool swiping = false;
        Vector2 position;
        SwipeHandler handler;


        private void Awake()
        {
            handler = new SwipeHandler();
            VirtualInput.RegisterHandler(handler);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (swiping)
            {
                handler.Update(position);
            }
        }

        void OnDestroy()
        {
            VirtualInput.UnregisterHandler(handler);
        }

        public void OnDrag(PointerEventData eventData)
        {
            swiping = true;
            position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            swiping = false;
            handler.ResetSwipe();
        }
    }

}
