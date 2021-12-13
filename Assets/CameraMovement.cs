using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float speed = 80f;
    

    [SerializeField][Range(50, 100)] float minRange;
    [SerializeField][Range(80, 150)] float maxRange;

    // Update is called once per frame
    void Update()

    {
        CamMove();
        CamScroll();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    void CamMove()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
    }
    void CamScroll()
    {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if (transform.position.y >= minRange && transform.position.y <= maxRange)
            {

            transform.Translate(0, 0, scroll * speed, Space.Self);
            if (transform.position.y < minRange)
                {

                    transform.position = new Vector3(transform.position.x, minRange, transform.position.z);
                }
                if (transform.position.y > maxRange)
                {

                    transform.position = new Vector3(transform.position.x, maxRange, transform.position.z);
                }
            }

        
    }
   
}



