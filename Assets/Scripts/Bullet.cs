using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedBullet;
    public float timeToDestroy;
    AudioSource aus;
    public AudioClip killESound;
    Rigidbody2D m_bl;
    // Start is called before the first frame update
    void Start()
    {
        m_bl = GetComponent<Rigidbody2D>();
        aus = FindObjectOfType<AudioSource>();
        Destroy(gameObject,timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        m_bl.velocity = Vector2.up * speedBullet;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")){
            Destroy(gameObject);
             if(aus && killESound){
                aus.PlayOneShot(killESound);
            }
        }
    }
}
