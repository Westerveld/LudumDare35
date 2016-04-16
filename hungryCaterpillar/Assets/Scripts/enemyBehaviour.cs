using UnityEngine;
using System.Collections;
using System.Linq;

public class enemyBehaviour : MonoBehaviour {

    private Transform[] food;
    private NavMeshAgent agent;
    private Vector3 goal;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] food = GameObject.FindGameObjectsWithTag("Food");
        goal = new Vector3(GetClosestTarget(food).position.x, GetClosestTarget(food).position.y, GetClosestTarget(food).position.z);
        agent.destination = goal;
	}

    Transform GetClosestTarget(GameObject[] food)
    {
        Transform bestTarget = null;

        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in food)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }

        return bestTarget;
    }
}
