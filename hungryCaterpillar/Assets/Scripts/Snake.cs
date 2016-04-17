using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

    public KeyCode up;
    public KeyCode down;
    public KeyCode right;
    public KeyCode left;

    public float speed;
    public static Vector2 dir = Vector2.right;
    bool ate = false;

    public static int health;


    public GameObject tailprefab;
    List<Transform> tail = new List<Transform>();

	// Use this for initialization
	void Start () {
        InvokeRepeating("Movement", 0.3f, speed);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(right) && dir != -Vector2.right) {
            dir = Vector2.right;
        } else if (Input.GetKey(up) && dir != -Vector2.up) {
            dir = Vector2.up;
        } else if (Input.GetKey(down) && dir != Vector2.up) {
            dir = -Vector2.up;
        } else if (Input.GetKey(left) && dir != Vector2.right) {
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
            GameObject g = (GameObject)Instantiate(tailprefab, v, /*Rotation.currAngle*/ Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
        } else if (tail.Count > 0) {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count() - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Food") {
            ate = true;
            Destroy(coll.gameObject);
            GameManager.Score++;
        }
        if(coll.tag == "Enemy" ||coll.tag == "Wall") {
            health--;
        }
    }

}
