using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0.01f, +0.0001f, +0.0f, Space.World);
        if(gameObject.name == "moon")
        {
            float PlanetRotateSpeed = -25.0f;
            var OrbitSpeed  = 10.0f;
            
            {
                // planet to spin on it's own axis
                transform.Rotate(transform.up * PlanetRotateSpeed * Time.deltaTime);

                // planet to travel along a path that rotates around the sun
                transform.RotateAround(Vector3.zero, Vector3.up, OrbitSpeed * Time.deltaTime);
            }
        }
    }
    private void OnMouseDown()
    {
        if(gameObject.name == "IcePlanet")
        {
            SceneManager.LoadScene("Level1");
        }
    }

}
