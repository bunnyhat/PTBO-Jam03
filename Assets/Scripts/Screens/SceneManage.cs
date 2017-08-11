using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {

	SceneManager m_sceneManager;
	bool m_gameOver = false;

	void Start () {
		
	}

	void Update () {
		
		if(Input.GetAxis("A") == 1 || Input.GetAxis("A_2") == 1){
			SceneManager.LoadScene("main");
		}

		if(m_gameOver == true) {
			SceneManager.LoadScene("GameOver");
		}
		
	}
}
