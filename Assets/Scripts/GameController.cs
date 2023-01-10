using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float spawnTime;
    public GameObject Enemy;

    UIManager m_ui;
    bool m_gameOver;
    float score;
    float m_spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        m_ui = FindObjectOfType<UIManager>();
        m_spawnTime = 0;
        score = 0;
        m_ui.setScore("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gameOver){
            m_ui.showGameOverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime <= 0) {
            spawnEnemy();
            m_spawnTime = spawnTime;
        }
    }
    public void spawnEnemy()
    {
        float xPos = Random.Range(-8f, 6f);
        Vector2 Pos = new Vector2(xPos, 5.5f);
        if (Enemy)
        {
            Instantiate(Enemy, Pos, Quaternion.identity);
        }
    }

    public void Replay(){
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Rplay");
         m_ui.showGameOverPanel(false);
    }
    public void IncrementScore(){
        score++;
        m_ui.setScore("Score: " + score);
    }

    public void setGameOverState(bool state){
        m_gameOver = state;
    }

    public bool getGameOverState(){
        return m_gameOver;
    }
}
