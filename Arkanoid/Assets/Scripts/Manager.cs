using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int score;

    [SerializeField]
    GameObject block;

    public static Manager instanceOf;

    public Manager()
    {
        instanceOf = this;
    }

    static Manager getInstanceOf()
    {
        if (instanceOf == null)
        {
            instanceOf = new Manager();
            return instanceOf;
        }

        return instanceOf;

    }


    // Start is called before the first frame update
    void Start()
    {
        for (float y = 9.5f; y> 5; y -= 0.9f)
        {
            for (float x = -4.25f; x <= 4.5; x += 1.2f)
            {
                Instantiate<GameObject>(block, new Vector3(x,y, -0.5f), Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
