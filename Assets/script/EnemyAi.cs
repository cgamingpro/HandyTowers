using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    NavMeshAgent agent;
    
    [SerializeField]List<Transform> WayPoints;
    [SerializeField]int currentWaypoint = 0;
    GameObject target;
    public bool isleft = true;
    GameObject wayPointParent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Goal");

        if(isleft)
        {
            wayPointParent = GameObject.Find("WayL");
            foreach(Transform t in wayPointParent.transform)
            {
                WayPoints.Add(t);
            }
        }    
        else if(!isleft)
        {
            wayPointParent = GameObject.Find("WayR");
            foreach (Transform t in wayPointParent.transform)
            {
                WayPoints.Add(t);
            }
        }
    }

   
    void Update()
    {
       
        if (agent.destination != WayPoints[currentWaypoint].position)
        {
            agent.destination = WayPoints[currentWaypoint].position;
        }
        if (Hasreached())
        {
            Debug.Log("has reached");
            currentWaypoint++;
            if (currentWaypoint >= WayPoints.Count)
            {
                currentWaypoint = WayPoints.Count - 1;
              
            }
        }




        
    }
    
    bool Hasreached()
    {
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + 0.2f;
    }

}
