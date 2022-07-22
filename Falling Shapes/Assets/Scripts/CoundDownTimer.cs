using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoundDownTimer : MonoBehaviour
{
    public float currentTime = 0;
    public float startingTime = 30;
    public GameObject mainCamera;
    
   

    [SerializeField] Text countdownText;
    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        if (mainCamera.GetComponent<genericRaycast>().yellowFrozen || mainCamera.GetComponent<genericRaycast>().redFrozen)
        {
            currentTime -= Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
            }
        }
        
        
    }
    
}
