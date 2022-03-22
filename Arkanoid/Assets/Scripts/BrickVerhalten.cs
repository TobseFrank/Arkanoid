using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickVerhalten : MonoBehaviour
{
    public Manager manager;
        
    public Material[] materials;
    
        
    int hitCount;
    int startCount;
    int troll;
    
    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        hitCount = random.Next(1,3);
        startCount = hitCount;
        GetComponent<Renderer>().material = materials[hitCount - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (hitCount == 0)
        {
            hitCount--;
            manager.score += startCount * 20;
            Debug.Log(manager.score);
            GetComponent<Renderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;

        }  
        if (hitCount > 0)
        {
            GetComponent<Renderer>().material = materials[hitCount - 1];
        }  

        if (troll >= 60)
        {
            troll = 0;
            hitCount--;
        } else if (hitCount > 0)
        {
            troll++;
        }
    }
}
