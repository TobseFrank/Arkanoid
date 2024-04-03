using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float x_dir = 1.0f;
    private float y_dir = 1.0f;

    [SerializeField]
    private float angle = 45.0f;

    private float lastBrickHit = 0;

    private void Awake() {
        x_dir = Random.Range(-1.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(x_dir * speed * Time.deltaTime ,y_dir * speed * Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Brick")){
            float currentTime = Time.time * 1000;
            if (lastBrickHit + 500 < currentTime) {
                y_dir *= -1;

            }
            lastBrickHit = currentTime; 
        }

        if (other.tag.Equals("Paddle")){            
            // Berechne den Punkt der Kollision
            float contactPointX = gameObject.transform.position.x - other.gameObject.transform.position.x;
            x_dir = Mathf.Clamp((contactPointX*angle / angle),-1f,+1f);          
            y_dir *= -1;
        }

        if (other.tag.Equals("TopBorder")){
            y_dir *= -1;
        }

        if (other.tag.Equals("SideBorder")){
            x_dir *= -1;
        }

        if (other.tag.Equals("DeathZone")){
            GameManager.Instance.ballsAlive--;
            GameManager.Instance.life--;
            Destroy(gameObject);
        }
        
    }
}
