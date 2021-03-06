﻿using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    public static Quaternion currAngle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Snake.dir == Vector2.right)
        {
            Quaternion right = new Quaternion();
            right.eulerAngles = new Vector3(0, 0, 0);
            transform.rotation = right;

        }
        else if (Snake.dir == Vector2.up)
        {
            Quaternion up = new Quaternion();
            up.eulerAngles = new Vector3(0, 0, 90);
            transform.rotation = up;
        }
        else if (Snake.dir == -Vector2.up)
        {
            Quaternion down = new Quaternion();
            down.eulerAngles = new Vector3(0, 0, -90);
            transform.rotation = down;
        }
        else if (Snake.dir == -Vector2.right)
        {
            Quaternion left = new Quaternion();
            left.eulerAngles = new Vector3(0, 0, 180);
            transform.rotation = left;
        }

        currAngle.eulerAngles = transform.rotation.eulerAngles;
	}
}
