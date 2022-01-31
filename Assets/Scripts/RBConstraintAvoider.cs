using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zoca.Controllers;

namespace Zoca.Utility
{
    public class RBConstraintAvoider : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if ("Player".Equals(other.tag))
            {
                Debug.Log("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
                other.GetComponent<PlayerController>().EnableConstraints(false);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if ("Player".Equals(other.tag))
            {
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                other.GetComponent<PlayerController>().EnableConstraints(true);
            }
        }
    }

}
