using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f, 5)]float speed = 1f;
    
    float CurrentSpeed;
    float multiplier = 1.0f;
    float current_multiplier;
    public bool moduleEnabled = false;
    bool slow_Active = false;
    
    List<Node> path = new List<Node>();

    Enemy enemy;
    GridManager gridManager;
    Pathfinder pathFinder;

    public ParticleSystem slow_Effect;

    // Start is called before the first frame update
    void OnEnable()
    {
        
        ReturnToStart();
        RecalculatePath(true);
        CurrentSpeed = speed;
        current_multiplier = multiplier;
        slow_Active = false;
        


    }

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<Pathfinder>();
        slow_Effect = FindObjectOfType<ParticleSystem>();
     
    }

    private void Update()
    {
      
    }
    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordintates = new Vector2Int();

        if (resetPath)
        {
            coordintates = pathFinder.StartCoordinates;
        }
        else
        {
            coordintates = gridManager.GetCoordinatesFromPosition(transform.position);
        }
        StopAllCoroutines();
        path.Clear();
        path = pathFinder.GetNewPath(coordintates);
        StartCoroutine(FollowPath());
    }
    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathFinder.StartCoordinates);
    }

    void finishPath()
    {
        enemy.DamageStructure();
        gameObject.SetActive(false);
    }
    IEnumerator FollowPath()
    {
        for(int i = 1; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * CurrentSpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);

                yield return new WaitForEndOfFrame();
            }

        
        }
        finishPath();
    }
    public void Slow_hit(float a)
    {
        current_multiplier -= a;
        StartCoroutine(Slow_Effect());
     
    }
  IEnumerator Slow_Effect() // Slows targets down for 2 seconds then return their speed and plays particle system.
    {
        if(slow_Active == false)
        {
            
            slow_Active = true;
            slow_Effect.Play();
            speed_change(current_multiplier); // add a negative multiplier from particlecollision to change speed.
            yield return new WaitForSeconds(2f);
           
            CurrentSpeed = speed; // return speed to start speed
            current_multiplier = multiplier;

            slow_Active = false;
            
        }


    }
    void speed_change(float a)
    {
        CurrentSpeed = CurrentSpeed * a;
    }
}
