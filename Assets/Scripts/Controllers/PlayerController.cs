using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zoca.Handlers;

namespace Zoca.Controllers
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
#if UNITY_EDITOR
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
#endif
            moveInput = new Vector2(VirtualInput.GetAxis("Horizontal").GetValue(), VirtualInput.GetAxis("Vertical").GetValue());

            // Calculate torque
            Vector2 targetTorqueDir = moveInput.normalized;
            float targetTorqueSpeed = moveInput.magnitude * maxTorqueSpeed;
            targetTorque = new Vector3(targetTorqueDir.y, 0, -targetTorqueDir.x) * targetTorqueSpeed;

        }

        private void FixedUpdate()
        {

            torque = Vector3.MoveTowards(torque, targetTorque, torqueAcceleration * Time.fixedDeltaTime);
            rb.AddTorque(torque, ForceMode.Force);
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
