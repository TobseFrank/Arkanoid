using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
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
        if (other.tag.Equals("Ball")){
            hit_count--;
            
            if (hit_count == 0) {
                CreateBuff(Random.Range(0,10));
                Destroy(gameObject);
            } else {
                gameObject.GetComponentInChildren<Renderer>().material = hitColors[hit_count-1];
            }
            
        }
    }

    private void CreateBuff(int random_number){
            if (random_number == 1) {
                Instantiate(buff, new Vector3(transform.position.x,transform.position.y,0),transform.rotation);
            }

            if (random_number == 9) {
                Instantiate(debuff, new Vector3(transform.position.x,transform.position.y,0),transform.rotation);
            }
    }
}
