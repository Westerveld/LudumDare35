using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

    public GameObject food;

    //borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    public float speed;
    public static Vector2 dir = Vector2.right;
    bool ate = false;


    public GameObject tailprefab;
    List<Transform> tail = new List<Transform>();

	// Use this for initialization
	void Start () {
        InvokeRepeating("Movement", 0.3f, speed);
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow) && dir != -Vector2.right) {
            dir = Vector2.right;
        } else if (Input.GetKey(KeyCode.UpArrow) && dir != -Vector2.up) {
            dir = Vector2.up;
        } else if (Input.GetKey(KeyCode.DownArrow) && dir != Vector2.up) {
            dir = -Vector2.up;
        } else if (Input.GetKey(KeyCode.LeftArrow) && dir != Vector2.right) {
            dir = -Vector2.right;
        }
	}

    void Movement()
    {
        //save current position
        Vector2 v = transform.position;

        transform.Translate(dir);
        if (ate)
        {
            GameObject g = (GameObject)Instantiate(tailprefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;

        }
        if (tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count() - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Food")
        {
            ate = true;
            Destroy(coll.gameObject);
            Spawn();
        }
    }

    void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        Instantiate(food, new Vector2(x, y), Quaternion.identity);
    }
}
