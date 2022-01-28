using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zoca.VirtualInputSystem.UI
{
    public class ImageRaycastAvoider : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Image>().raycastTarget = false;
        }


    }

}
