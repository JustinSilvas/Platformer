using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPointRotation : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 separation = target.transform.position - transform.position;
        float angle = Mathf.Atan2(separation.y, separation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
    }
}
