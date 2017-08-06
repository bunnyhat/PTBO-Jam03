using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpDerp : MonoBehaviour {

	public bool m_isActive;

	public bool m_isBarFull;

	public Image m_image;

	public float zuckFee;

	// Use this for initialization
	void Start () {
		 m_isActive = false;
		 m_isBarFull = false;
	}

	public void BarFull(){
		if(m_isBarFull){
			m_isActive = true;
			m_image.color = Color.Lerp(Color.black, Color.white, Mathf.PingPong(Time.time, 1));
		} else {
			m_isActive = false;
			m_image.color = Color.black;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		BarFull();
	}
}
