using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    public KeyCode up;
    public KeyCode down;
    public KeyCode right;
    public KeyCode left;
    public static Quaternion currAngle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(right) && Snake.dir == Vector2.right)
        {
            Quaternion right1 = new Quaternion();
            right1.eulerAngles = new Vector3(0, 0, 0);
            transform.rotation = right1;

        }
        else if (Input.GetKey(up) && Snake.dir == Vector2.up)
        {
            Quaternion up1 = new Quaternion();
            up1.eulerAngles = new Vector3(0, 0, 90);
            transform.rotation = up1;
        }
        else if (Input.GetKey(down) && Snake.dir == -Vector2.up)
        {
            Quaternion down1 = new Quaternion();
            down1.eulerAngles = new Vector3(0, 0, -90);
            transform.rotation = down1;
        }
        else if (Input.GetKey(left) && Snake.dir == -Vector2.right)
        {
            Quaternion left1 = new Quaternion();
            left1.eulerAngles = new Vector3(0, 0, 180);
            transform.rotation = left1;
        }

        currAngle.eulerAngles = transform.rotation.eulerAngles;
	}
}
