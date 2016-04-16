using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int Score;
    public Text scoreLabel;

	void Start () {
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
}
