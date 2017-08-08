using UnityEngine;

public class GameOver : MonoBehaviour {

	public string GameOverWinCheck(int P1Score, int P2Score) {
		string winner = "";
		P1Score = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Player>().m_score;
		P2Score = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Player>().m_score;

		if(P1Score > P2Score) {
			winner = "Player 1 Wins";
		} else if(P2Score > P1Score) {
			winner = "Player 2 Wins";
		}

		return winner;
	}
}
