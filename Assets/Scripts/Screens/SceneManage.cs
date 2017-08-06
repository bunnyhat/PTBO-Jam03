using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {

	SceneManager m_sceneManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("A") == 1 || Input.GetAxis("A_2") == 1){
			SceneManager.LoadScene("main");
		}
		
	}
}
