using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        float distance = 3;

        [SerializeField]
        float pitch = 60;

        [SerializeField]
        float height = 5;

        Transform ball;
        Vector3 velocity;
        float smoothTime = 0.3f;

        // Start is called before the first frame update
        void Start()
        {
            ball = GameObject.FindGameObjectWithTag("Player").transform;

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
            transform.LookAt(ball);
            Vector3 eulers = transform.eulerAngles;
            eulers.x = pitch;
            transform.eulerAngles = eulers;

            

        }



        Vector3 GetTargetPosition()
        {
            Vector3 ret = ball.transform.position;

            ret.y += height;
            //ret.x = 0;
            ret.z -= distance;

            return ret;
        }
    }

}
