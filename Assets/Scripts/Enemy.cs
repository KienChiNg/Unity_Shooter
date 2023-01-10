using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedEnemy;
    UIManager m_ui;
    GameController m_gc;
    AudioSource aus;
    public AudioClip gameOverSound;
    Rigidbody2D m_e;
    
    // Start is called before the first frame update
    void Start()
    {
        aus = FindObjectOfType<AudioSource>();
        m_e = GetComponent<Rigidbody2D>();
        m_ui = FindObjectOfType<UIManager>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (m_gc.getGameOverState()){
        //     return;
        // }
        m_e.velocity = Vector2.down * speedEnemy;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet")){
            Debug.Log("VachamBullett");
            m_gc.IncrementScore();
            Destroy(gameObject);  
           
        }else if(other.CompareTag("DeathZone")||other.CompareTag("Player")){
            Debug.Log("GameOver");
            m_gc.setGameOverState(true);
            Destroy(gameObject);  
            if ( aus && gameOverSound){
                aus.PlayOneShot(gameOverSound);
                aus.Stop();
            }
        }
    }
}
