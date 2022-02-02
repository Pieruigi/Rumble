using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.Gameplay
{
    public class Mine : MonoBehaviour
    {
        #region private fields
        [SerializeField]
        float explosionPower;

        SphereCollider coll;
        #endregion



        #region private methods
        private void Awake()
        {
            coll = GetComponent<SphereCollider>();
        }

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
            if (Tag.Player.Equals(other.tag))
            {
                // Trigger explosion
                Vector3 forceDir = other.transform.position - transform.position;
                forceDir = forceDir.normalized;
                other.GetComponent<Rigidbody>().AddForce(explosionPower * forceDir, ForceMode.Impulse);
            }
        }

        #endregion

    }

}
