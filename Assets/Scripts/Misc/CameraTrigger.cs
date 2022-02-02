using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zoca.Controllers;

namespace Zoca
{
    public class CameraTrigger : MonoBehaviour
    {
       
        [SerializeField]
        float displacementX;

        [SerializeField]
        float time = 2;

        CameraController cameraController;
        float defaultDisplacementX;

        bool loop = false;
        float elapsed = 0;
        float velocity;
        float targetDispX;


        // Start is called before the first frame update
        void Start()
        {
            cameraController = Camera.main.GetComponent<CameraController>();
            defaultDisplacementX = cameraController.Displacement.x;
        }

        // Update is called once per frame
        void Update()
        {
            if (!loop)
                return;

            cameraController.SetDisplacementX(Mathf.SmoothDamp(cameraController.Displacement.x, targetDispX, ref velocity, time));
            if (cameraController.Displacement.x == targetDispX)
                loop = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (Tag.Player.Equals(other.tag))
            {
                loop = true;
                
                targetDispX = displacementX;
                //cameraController.SetDisplacementX(displacementX);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (Tag.Player.Equals(other.tag))
            {
                loop = true;
                elapsed = 0;
                targetDispX = defaultDisplacementX;
                //cameraController.ResetDisplacementX();
            }
        }

    }

}
