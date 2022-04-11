using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AL start
public class playerforcerope : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//AL end
