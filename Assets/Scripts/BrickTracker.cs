using UnityEngine;

public class BrickTracker : MonoBehaviour {

	public int m_middleBricksLeft;
	// public int[ , ] m_brickGrid;

	void Start(){
		// m_brickGrid = new int[GameObject.FindGameObjectWithTag("Playfield").GetComponent<BricksManager>().GetFieldHeight, GameObject.FindGameObjectWithTag("Playfield").GetComponent<BricksManager>().GetFieldWidth];
		m_middleBricksLeft = 17;
	}

	public int GetBrickCount(){
		m_middleBricksLeft--;
		return m_middleBricksLeft;
	}

	public void NotifyGameOver() {
		if(m_middleBricksLeft == 0) {

			// GetComponent<GameOver>().GameOverWinCheck();
		}
	}
}
