using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zoca.VirtualInputSystem;

namespace Zoca.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        float maxTorque = 10;
        
      
        //[SerializeField]
        //float maxForce = 10;


        Rigidbody rb;
        Vector2 moveInput;

        Vector3 targetTorque;
        Vector3 torque;
        SphereCollider coll;
        bool freezeY = false;
        

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.maxAngularVelocity = Mathf.Infinity;
            coll = GetComponent<SphereCollider>();
        }

        private void Start()
        {
            //rb.AddTorque(Vector3.right * 10, ForceMode.VelocityChange);
        }

        private void Update()
        {
           

#if UNITY_EDITOR
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
#endif
            moveInput = new Vector2(VirtualInput.GetAxis("Horizontal"), VirtualInput.GetAxis("Vertical"));

            

        }

        private void FixedUpdate()
        {
            if(freezeY)
                rb.constraints = RigidbodyConstraints.FreezePositionY;
            else
                rb.constraints = RigidbodyConstraints.None;

            Vector3 t = maxTorque * new Vector3(moveInput.y, 0, -moveInput.x);
            //Debug.Log("Torque:" + t);
            rb.AddTorque(t, ForceMode.Force);
            //Debug.Log("Rb.AngularVelocity:" + rb.angularVelocity);
            //rb.AddForce(maxForce * new Vector3(moveInput.x, 0, moveInput.y), ForceMode.Force);
            CheckGrounded();
        }

        void CheckGrounded()
        {
            float radius = coll.radius+0.01f;
            Ray ray = new Ray(rb.position, Vector3.down);
            coll.enabled = false;
            RaycastHit info;
            if(Physics.Raycast(ray, out info, radius))
            {
                // Reset vertical position
                rb.MovePosition(new Vector3(rb.position.x, info.point.y + coll.radius, rb.position.z));

                // Since it seems that setting and then freezing position in the same frame avoids the ball 
                // to move, we set the vertical constraints to the next FixedUpdate
                freezeY = true;
            }
            else
            {
                freezeY = false;
            }
            coll.enabled = true;

        }

#if old
        #region private fields
        [SerializeField]
        float maxPitch = 20;

        [SerializeField]
        float maxRoll = 20;

        [SerializeField]
        float angularSpeed = 360;

        Vector2 moveInput;
        float pitch;
        float roll;
        #endregion

        #region private methods

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Check input
#if UNITY_EDITOR
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
#endif
            Debug.Log("MoveInput:" + moveInput);
            // Compute pitch and roll angles
            float pitchTarget = Mathf.Lerp(-maxPitch, maxPitch, (moveInput.y + 1) / 2f);
            float rollTarget = Mathf.Lerp(-maxRoll, maxRoll, (moveInput.x + 1) / 2f);
            Debug.Log("pitchTarget:" + pitchTarget);
            Debug.Log("rollTarget:" + rollTarget);
            // Rotate
            pitch = Mathf.MoveTowards(pitch, pitchTarget, angularSpeed * Time.deltaTime);
            roll = Mathf.MoveTowards(roll, rollTarget, angularSpeed * Time.deltaTime);
            Vector3 eulers = transform.eulerAngles;
            eulers.x = pitch;
            eulers.z = -roll;
            transform.eulerAngles = eulers;
        }


        void CheckInput()
        {



        }

        #endregion
#endif
    }

}
