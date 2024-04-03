using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePaddle : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private GameObject ammo;

    [SerializeField]
    private GameObject rightBorder;

    [SerializeField]
    private GameObject leftBorder;

    [SerializeField]
    private float speed;

    [SerializeField]
    Material[] paddleColor;

    public float paddleShoots = 0;

    private float lastTimeScaleChanged = 0;
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.S)) {
            if (GameManager.Instance.ballsAlive == 0) {
                if (GameManager.Instance.life > 0) {
                    Instantiate(ball, new Vector3(transform.position.x,-3.5f,-0.5f), transform.rotation);
                    GameManager.Instance.ballsAlive++;
                }
            }
        }
        

        if (Time.time - lastTimeScaleChanged > 5) {
            transform.localScale = new Vector3(2,1,1);
        }


        float dir = Input.GetAxis("Horizontal");
        //transform.position += new Vector3(dir * speed * Time.deltaTime,0,0);

        float xMax = (rightBorder.transform.position.x - (rightBorder.transform.localScale.x * 0.5f)) - transform.localScale.x * 0.5f;
        float xMin = (leftBorder.transform.position.x + (leftBorder.transform.localScale.x * 0.5f))+ transform.localScale.x * 0.5f;

        float xPlayerNew = transform.position.x + dir * Time.deltaTime * speed;
        float xActual = Mathf.Clamp(xPlayerNew, xMin, xMax);
        transform.position = new Vector3(xActual, transform.position.y, transform.position.z);
        if (paddleShoots > 0) {
            gameObject.GetComponentInChildren<Renderer>().material = paddleColor[1];
            if (Input.GetKeyDown(KeyCode.Space)) {
                Instantiate(ammo, new Vector3(transform.position.x - 0.5f,transform.position.y,-0.5f),transform.rotation);
                Instantiate(ammo, new Vector3(transform.position.x + 0.5f,transform.position.y,-0.5f),transform.rotation);
                paddleShoots--;
            }
        } else {
                gameObject.GetComponentInChildren<Renderer>().material = paddleColor[0];
        }          

    }

    private void OnTriggerEnter(Collider other){
         if (other.tag.Equals("Buff")){
            switch (Random.Range(1,3))
            {
                case 1:
                paddleShoots += 3;
                break;

                case 2:
                transform.localScale = new Vector3(4,1,1);
                lastTimeScaleChanged = Time.time;
                break;

                default:
                Debug.Log("");
                break;
            }
            Destroy(other.gameObject);
        }
         if (other.tag.Equals("Debuff")){
            transform.localScale = new Vector3(1,1,1);
            lastTimeScaleChanged = Time.time;
            Destroy(other.gameObject);
        }
    }
}
