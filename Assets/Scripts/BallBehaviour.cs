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

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(x_dir * speed * Time.deltaTime ,y_dir * speed * Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Brick")){
            y_dir *= -1;
        }

        if (other.tag.Equals("Paddle")){
            y_dir *= -1;
        }

        if (other.tag.Equals("TopBorder")){
            y_dir *= -1;
        }

        if (other.tag.Equals("SideBorder")){
            x_dir *= -1;
        }
        
    }
}
