using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePaddle : MonoBehaviour
{

    [SerializeField]
    private GameObject ammo;

    [SerializeField]
    private float speed;

    private float width;

    // Start is called before the first frame update
    void Start()
    {
        //width = transform.position.Scale();
        //this.GetComponent<Transform>().position = new Vector3(3,0,0);
    }

    // Update is called once per frame
    void Update()
    {   
        float dir = Input.GetAxis("Horizontal");
        transform.position += new Vector3(dir * speed * Time.deltaTime,0,0);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(ammo, new Vector3(transform.position.x - 0.5f,transform.position.y,0),transform.rotation);
            Instantiate(ammo, new Vector3(transform.position.x + 0.5f,transform.position.y,0),transform.rotation);
        }
    }
}
