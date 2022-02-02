using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zoca.Managers;

namespace Zoca.UI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        TMP_Text timerText;

        string timerFormat = "{0:mm:ss.fff}";
        DateTime startTime;

        private void Awake()
        {
            
            DateTime d = new DateTime();
            d = d.AddMilliseconds(112021);
            
        }

        // Start is called before the first frame update
        void Start()
        {
            LevelManager.Instance.OnLevelStarted += (DateTime startTime) => { this.startTime = startTime; };
        }

        // Update is called once per frame
        void Update()
        {
            if (LevelManager.Instance.Running)
            {
                float millis = (float)(DateTime.UtcNow - startTime).TotalMilliseconds;
                timerText.text = string.Format(timerFormat, new DateTime().AddMilliseconds(millis));
            }
        }
    }

}
