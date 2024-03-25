using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePaddle : MonoBehaviour
{

    [SerializeField]
    private GameObject ammo;

    [SerializeField]
    private GameObject rightBorder;

    [SerializeField]
    private GameObject leftBorder;

    [SerializeField]
    private float speed;

    // Update is called once per frame
    void Update()
    {   
        float dir = Input.GetAxis("Horizontal");
        //transform.position += new Vector3(dir * speed * Time.deltaTime,0,0);

        float xMax = (rightBorder.transform.position.x - (rightBorder.transform.localScale.x * 0.5f)) - transform.localScale.x * 0.5f;
        float xMin = (leftBorder.transform.position.x + (leftBorder.transform.localScale.x * 0.5f))+ transform.localScale.x * 0.5f;

        float xPlayerNew = transform.position.x + dir * Time.deltaTime * speed;
        float xActual = Mathf.Clamp(xPlayerNew, xMin, xMax);
        transform.position = new Vector3(xActual, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(ammo, new Vector3(transform.position.x - 0.5f,transform.position.y,0),transform.rotation);
            Instantiate(ammo, new Vector3(transform.position.x + 0.5f,transform.position.y,0),transform.rotation);
        }
    }
}
