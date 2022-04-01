using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickVerhalten : MonoBehaviour
{
    private Manager manager = Manager.instanceOf;
    public Material[] materials;
    
    [SerializeField]
    int minLife;
    
    [SerializeField]
    int maxLife;  
        
    private int hitCount;
    private int startCount;
    private int troll;
    
    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        hitCount = random.Next(minLife,maxLife);
        startCount = hitCount;
        this.GetComponent<Renderer>().material = materials[hitCount - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (hitCount == 0)
        {
            hitCount--;
            manager.score += startCount * 20;
            Debug.Log(manager.score);
            this.GetComponent<Renderer>().forceRenderingOff = true;
            this.GetComponent<BoxCollider>().isTrigger = false;
        }  
        if (hitCount > 0)
        {
            this.GetComponent<Renderer>().material = materials[hitCount - 1];
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
