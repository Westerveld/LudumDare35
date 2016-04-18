using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endScene : MonoBehaviour {

    public Text player1Score;
    public Text player2Score;
    public Text winnerText;

    public Texture btnTexture;

	// Use this for initialization
	void Start () {
        int score1 = GameManager.Score;
        int score2 = GameManager.Score2;
        player1Score.text = "Player 1 Score: " + score1;
        player2Score.text = "Player 2 Score: " + score2;
        if(score1 > score2){
            winnerText.text = "Player 1 Wins!";
        }
        else if (score2 > score1)
        {
            winnerText.text = "Player 2 Wins!";
        }
        else
        {
            winnerText.text = "It's a Draw!";
        }

	}


    public void homeScene()
    {
        SceneManager.LoadScene("start");
    }
}
