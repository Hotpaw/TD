using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlekill : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 5)
        {
            Destroy(gameObject);
        }
        Debug.Log(time);
    }
}