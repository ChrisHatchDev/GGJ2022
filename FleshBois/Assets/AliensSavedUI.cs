using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AliensSavedUI : MonoBehaviour
{
    public Text textComponent;

    void Update()
    {
        textComponent.text = GameManager.Instance.score.getTotalSaved().ToString() + "/" + GameManager.Instance.score.getTotalAliens().ToString();
    }
}
