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
        #endregion


        #region private methods
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
            }
        }

        #endregion

    }

}
