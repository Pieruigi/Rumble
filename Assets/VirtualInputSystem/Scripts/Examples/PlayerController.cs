using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zoca.VirtualInputSystem.Handlers;

namespace Zoca.VirtualInputSystem.Examples
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        float maxTorqueSpeed = 10;
        
        [SerializeField]
        float torqueAcceleration;



        Rigidbody rb;
        Vector2 moveInput;

        Vector3 targetTorque;
        Vector3 torque;
        bool flying = false;
        bool grounded = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            //rb.AddTorque(Vector3.right * 10, ForceMode.VelocityChange);
        }

        private void Update()
        {
            // Move
#if UNITY_EDITOR
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
#endif
            moveInput = new Vector2(VirtualInput.GetAxis("Horizontal"), VirtualInput.GetAxis("Vertical"));

            // Calculate torque
            Vector2 targetTorqueDir = moveInput.normalized;
            float targetTorqueSpeed = moveInput.magnitude * maxTorqueSpeed;
            targetTorque = new Vector3(targetTorqueDir.y, 0, -targetTorqueDir.x) * targetTorqueSpeed;


            // Jump
            if (VirtualInput.GetButtonDown("Jump"))
            {
                //Debug.Log("Button Jump down");
                if(grounded)
                    rb.AddForce(Vector3.up * 3, ForceMode.Impulse);
                 
            }

            if (VirtualInput.GetButton("Jump"))
            {
                //Debug.Log("Button Jump");
                flying = true;
                
            }

            if (VirtualInput.GetButtonUp("Jump"))
            {
                //Debug.Log("Button Jump up");
                flying = false;
               
            }
        }

        private void FixedUpdate()
        {

            torque = Vector3.MoveTowards(torque, targetTorque, torqueAcceleration * Time.fixedDeltaTime);
            rb.AddTorque(torque, ForceMode.Force);

            if(flying)
                rb.AddForce(Vector3.up * 7.5f, ForceMode.Acceleration);
        }

        private void OnCollisionStay(Collision collision)
        {
            if ("Floor".Equals(collision.gameObject.tag))
                grounded = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            if ("Floor".Equals(collision.gameObject.tag))
                grounded = false;
        }
    }

}
