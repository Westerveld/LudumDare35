using UnityEngine;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class enemyBehaviour : MonoBehaviour {

    public Transform target;

    //How often we update the path
    public float updateRate = 2f;

    //Caching
    private Seeker seeker;
    private Rigidbody2D rb;

    //The path
    public Path path;

    //Ai speed/s
    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    private bool ate = false; 

    private bool searchingForTarget = false;

    //The max distance from AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;

    public GameObject tailprefab;
    List<Transform> tail = new List<Transform>();

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        if (target == null)
        {
            if (!searchingForTarget)
            {
                searchingForTarget = true;
                StartCoroutine(SearchForTarget());
            }
            return;
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator SearchForTarget()
    {
        GameObject sResult = GameObject.FindGameObjectWithTag("Food");
        if (sResult == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchForTarget());
        }
        else
        {
            target = sResult.transform;
            searchingForTarget = false;
            StartCoroutine(UpdatePath());
        }

    }


    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            if (!searchingForTarget)
            {
                searchingForTarget = true;
                StartCoroutine(SearchForTarget());
            }
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        yield return new WaitForSeconds(1f/updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("Path " + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }

    }

    void FixedUpdate()
    {
        if (target == null)
        {
            if (!searchingForTarget)
            {
                searchingForTarget = true;
                StartCoroutine(SearchForTarget());
            }
            return;
        }

        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }

            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;
        Vector2 v = transform.position;
        v.x += 0.1f;
        v.y += 0.1f;
        rb.AddForce(dir, fMode);
        if (ate)
        {
            GameObject g = (GameObject)Instantiate(tailprefab, v, /*Rotation.currAngle*/ Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
        }
        else if (tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count() - 1);
        }
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Food")
        {
            ate = true;
            Destroy(col.gameObject);
        }
    }
}
