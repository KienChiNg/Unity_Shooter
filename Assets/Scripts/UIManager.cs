using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text Score;
    public GameObject GameOverPanel;
    // Start is called before the first frame update
    public void setScore(string txt){
        Score.text = txt;
    }
    public void showGameOverPanel(bool state){
        GameOverPanel.SetActive(state);
    }
}
