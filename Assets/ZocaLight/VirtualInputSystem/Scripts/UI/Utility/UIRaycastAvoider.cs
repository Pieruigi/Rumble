using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zoca.VirtualInputSystem.UI
{
    public class UIRaycastAvoider : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<MaskableGraphic>().raycastTarget = false;
            
        }


    }

}
