using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed;


    void Start()
    {
        transform.position =  new Vector3(0f, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxis("Horizontal");
        transform.position += new Vector3(dir * speed * Time.deltaTime, 0, 0);
    }
}
