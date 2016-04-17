using UnityEngine;
using System.Collections;

public class RotationPlayer : MonoBehaviour {

    public KeyCode up;
    public KeyCode down;
    public KeyCode right;
    public KeyCode left;
    public static Quaternion currAngle;

	// Use this for initialization
    void Update()
    {
        if (Input.GetKey(right) && SnakePlayer2.dir == Vector2.right)
        {
            Quaternion right1 = new Quaternion();
            right1.eulerAngles = new Vector3(0, 0, 180);
            transform.rotation = right1;

        }
        else if (Input.GetKey(up) && SnakePlayer2.dir == Vector2.up)
        {
            Quaternion up1 = new Quaternion();
            up1.eulerAngles = new Vector3(0, 0, -90);
            transform.rotation = up1;
        }
        else if (Input.GetKey(down) && SnakePlayer2.dir == -Vector2.up)
        {
            Quaternion down1 = new Quaternion();
            down1.eulerAngles = new Vector3(0, 0, 90);
            transform.rotation = down1;
        }
        else if (Input.GetKey(left) && SnakePlayer2.dir == -Vector2.right)
        {
            Quaternion left1 = new Quaternion();
            left1.eulerAngles = new Vector3(0, 0, 0);
            transform.rotation = left1;
        }

        currAngle.eulerAngles = transform.rotation.eulerAngles;
    }
}
