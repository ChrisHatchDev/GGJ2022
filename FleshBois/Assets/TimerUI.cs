using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Text TimerText;
    // Start is called before the first frame update
    void Start()
    {
        TimerText.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = GameManager.Instance.gameTimer.timeText;
        
    }
}
