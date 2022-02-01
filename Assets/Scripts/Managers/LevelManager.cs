using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Zoca.Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region events
        public UnityAction<DateTime> OnLevelStarted;
        #endregion

        #region properties
        public static LevelManager Instance { get; private set; }

        public DateTime StartTime
        {
            get { return startTime; }
        }

        public bool Running
        {
            get { return running; }
        }

        #endregion

        #region private fields
        float startDelay = 1;
        bool running = false;
        DateTime startTime;
        #endregion

        #region private methods

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(DelayStart());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator DelayStart()
        {
            yield return new WaitForSeconds(startDelay);

            running = true;
            startTime = DateTime.UtcNow;

            OnLevelStarted?.Invoke(startTime);

        }
        #endregion
    }

}
