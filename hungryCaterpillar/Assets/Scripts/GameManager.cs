using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int Score;
    public Text scoreLabel;
    public static int Score2;
    public Text score2Label;

    public GameObject food;
    //borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

	void Start () {
        InvokeRepeating("Spawn", 3f, 2f);
        Score = 0;
        Score2 = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        scoreLabel.text = "Score: " + Score;
        score2Label.text = "Score: " + Score2;
    }

    public static void endGame()
    {
        SceneManager.LoadScene("end");
    }

    void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x + 2f, borderRight.position.x - 2f);
        int y = (int)Random.Range(borderBottom.position.y + 2f, borderTop.position.y - 2f);

        Instantiate(food, new Vector2(x, y), Quaternion.identity);
    }
}
