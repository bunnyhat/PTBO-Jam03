using UnityEngine;

public class BrickTracker : MonoBehaviour {

	public int m_middleBricksLeft;

	void Start(){
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
