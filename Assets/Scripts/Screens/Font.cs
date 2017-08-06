using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Font : MonoBehaviour {
	public Text m_text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	m_text.color = Color.Lerp(Color.cyan, Color.magenta, Mathf.PingPong(Time.time, 1));
	}
}
