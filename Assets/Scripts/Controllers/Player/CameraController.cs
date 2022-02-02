using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.Controllers
{
    public class CameraController : MonoBehaviour
    {
       
        public Vector3 Displacement
        {
            get { return displacement; }
        }

        [SerializeField]
        Vector3 displacement;

        //[SerializeField]
        //float distance = 3;

        [SerializeField]
        float pitch = 60;

        //[SerializeField]
        //float height = 5;

        [SerializeField]
        float smoothTime = 0.3f;

        Transform ball;
        Vector3 velocity;
      
        
        // Start is called before the first frame update
        void Start()
        {
            ball = GameObject.FindGameObjectWithTag(Tag.Player).transform;

            transform.position = GetTargetPosition();
            Vector3 eulers = transform.eulerAngles;
            eulers.x = pitch;
            transform.eulerAngles = eulers;


        }

        // Update is called once per frame
        void Update()
        {

        }

        private void LateUpdate()
        {
            // Get the target position
            Vector3 targetPosition = GetTargetPosition();

            // Move to the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);



            // Rotation
            transform.LookAt(ball.position);
            Vector3 eulers = transform.eulerAngles;
            eulers.x = pitch;
            transform.eulerAngles = eulers;

            

        }



        Vector3 GetTargetPosition()
        {
            Vector3 ret = ball.transform.position + displacement;

            //ret.y += height;
            ////ret.x = 0;
            //ret.z -= distance;

            return ret;
        }

        public void SetDisplacementX(float displacementX)
        {
            this.displacement.x = displacementX;
        }

    
        
    }

}
