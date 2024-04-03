using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    
    [SerializeField]
    GameObject gameManager;

    [SerializeField]
    int hit_count;

    [SerializeField]
    GameObject buff;
    [SerializeField]
    GameObject debuff;

    [SerializeField]
    Material[] hitColors;

    private void Start() {        
        gameObject.GetComponentInChildren<Renderer>().material = hitColors[hit_count-1];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ball") || other.tag.Equals("Ammo")){
            hit_count--;
            
            if (hit_count == 0) {
                CreateBuff(Random.Range(0,10));

                GameManager.Instance.score += 100;

                Destroy(gameObject);
            } else {
                gameObject.GetComponentInChildren<Renderer>().material = hitColors[hit_count-1];
            }

            if (other.tag.Equals("Ammo")) {
                Destroy(other.gameObject);
            }
        }
    }

    private void CreateBuff(int random_number){
            if (random_number == 1) {
                Instantiate(buff, new Vector3(transform.position.x,transform.position.y,-0.5f),transform.rotation);
            }

            if (random_number == 9) {
                Instantiate(debuff, new Vector3(transform.position.x,transform.position.y,-0.5f),transform.rotation);
            }
    }
}
