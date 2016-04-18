using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int Score;
    public Text scoreLabel;
    public static int Score2;
    public Text score2Label;

    public static int player1Life;
    public static int player2Life;

    public GameObject food;
    public GameObject rock;
    //borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;
    private int count = 0;

	void Start () {
        InvokeRepeating("Spawn", 3f, 2f);
        InvokeRepeating("SpawnRock", 10f, 2f);
        Score = 0;
        Score2 = 0;
        player1Life = 5;
        player2Life = 5;
	}
	
	// Update is called once per frame
	void Update () {

        if (player1Life == 0 || player2Life == 0)
        {
            endGame();
        }
        if ((Score - Score2) >= 20)
        {
            endGame();
        }
        if ((Score2 - Score) >= 20)
        {
            endGame();
        }
        
	}

    void FixedUpdate()
    {
        scoreLabel.text = "Player 1 Score: " + Score;
        score2Label.text = "Player 2 Score: " + Score2;
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

    void SpawnRock()
    {
        int x = (int)Random.Range(borderLeft.position.x + 2f, borderRight.position.x - 2f);
        int y = (int)Random.Range(borderBottom.position.y + 2f, borderTop.position.y - 2f);
        if (count < 5)
        {
            Instantiate(rock, new Vector2(x, y), Quaternion.identity);
            count++;
        }
        else
        {
            GameObject deleteRock = GameObject.FindGameObjectWithTag("Rock");
            Destroy(deleteRock);
            count--;
        }
    }
}
