using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject Bullet;
    public Transform shootingPosition;
    public AudioSource aus;
    public AudioClip shootSound;

    GameController m_gc;

    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.getGameOverState()){
            aus.Stop();
            return;
        }
        float xDir = Input.GetAxisRaw("Horizontal");
        if ((xDir < 0 && transform.position.x <= -8.15) || (xDir > 0 && transform.position.x >= 6.8)){
            return;
        }
        transform.position += Vector3.right * moveSpeed * xDir * Time.deltaTime; 
        if (Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
    }

    public void Shoot (){
        if (Bullet && shootingPosition) {
            Instantiate(Bullet,shootingPosition.position,Quaternion.identity);
            if(aus && shootSound){
                aus.PlayOneShot(shootSound);
            }
        }
    }
}
