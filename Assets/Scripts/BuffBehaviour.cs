using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Update is called once per frame
    void Update()
    {
        float dir = -1.0f;
        transform.position += new Vector3(0,dir * speed * Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("DeathZone")){
            Destroy(gameObject);
        }
        
    }
    
}
