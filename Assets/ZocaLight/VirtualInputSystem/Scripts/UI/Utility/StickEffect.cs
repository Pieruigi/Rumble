using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zoca.VirtualInputSystem.UI
{
    public class StickEffect : MonoBehaviour
    {
        Image image;

        private void Awake()
        {
            image = GetComponent<Image>();

            VirtualJoystick joystick = GetComponentInParent<VirtualJoystick>();
            joystick.OnPressed += delegate { image.enabled = true; };
            joystick.OnReleased += delegate { image.enabled = false; };

            image.enabled = false;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
