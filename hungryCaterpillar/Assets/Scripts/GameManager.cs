using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int Score;
    public Text scoreLabel;

    public GameObject food;
    //borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

	void Start () {

        InvokeRepeating("Spawn", 3f, 2f);
        Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        scoreLabel.text = "Score: " + Score;
    }

    public static void endGame()
    {
        SceneManager.LoadScene("end");
    }

    void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x + 1, borderRight.position.x - 1);
        int y = (int)Random.Range(borderBottom.position.y + 1, borderTop.position.y - 1);

        Instantiate(food, new Vector2(x, y), Quaternion.identity);
    }
}
