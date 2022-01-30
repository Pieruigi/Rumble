using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zoca.VirtualInputSystem.Examples
{
    public class TapAndSwipeTester : MonoBehaviour
    {
        [SerializeField]
        GameObject pointer;

        [SerializeField]
        GameObject log;

        [SerializeField]
        Text actionText;

        [SerializeField]
        Text durationText;

        [SerializeField]
        Text deltaText;

        [SerializeField]
        Text speedText;

        [SerializeField]
        Text avgSpeedText;

        [SerializeField]
        Text distanceText;



        float logTime = 5f;
        float logElapsed = 0;
        float redLogElapsed = 0;

        // Start is called before the first frame update
        void Start()
        {
            log.SetActive(false);
            pointer.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            Data.TapData tapData;
            if(VirtualInput.GetTap(out tapData))
            {
                Debug.Log("TapData.position:" + tapData.Position);
                (pointer.transform as RectTransform).anchoredPosition = tapData.Position;
                logElapsed = logTime;
                //logText.text = "Tap";
                pointer.SetActive(true);
                log.SetActive(true);
                actionText.text = "Tapping";
                durationText.text = tapData.Duration.ToString();
                deltaText.text = "";
                distanceText.text = "";
                speedText.text = "";
                avgSpeedText.text = "";
            }
            

            Data.SwipeData swipeData;
            if (VirtualInput.GetSwipe(out swipeData))
            {
                (pointer.transform as RectTransform).anchoredPosition = swipeData.Position;
                logElapsed = logTime;
                //logText.text = "Swipe";
                pointer.SetActive(true);
                log.SetActive(true);
                actionText.text = "Swapping";
                durationText.text = swipeData.Duration.ToString();
                deltaText.text = swipeData.Delta.ToString();
                distanceText.text = swipeData.Distance.ToString();
                speedText.text = swipeData.Speed.ToString();
                avgSpeedText.text = swipeData.AverageSpeed.ToString();
            }
            
            CheckLog();
            
        }

        void CheckLog()
        {
            if (logElapsed > 0)
            {
                logElapsed -= Time.deltaTime;
                if (logElapsed <= 0)
                    log.SetActive(false);
            }
        }

    }

}
