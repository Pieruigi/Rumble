using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zoca.VirtualInputSystem.UI
{
    public class ButtonEffect : MonoBehaviour
    {


        private void Awake()
        {
            Color defaultColor = GetComponent<Image>().color;

            // Set handlers 
            GetComponent<VirtualButton>().OnButtonDown += delegate { this.GetComponent<Image>().color = defaultColor * 1.4f; };
            GetComponent<VirtualButton>().OnButtonUp += delegate { this.GetComponent<Image>().color = defaultColor; };
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
