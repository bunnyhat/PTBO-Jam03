using UnityEngine;

public enum BrickState {
	SPAWNED,
	DESTROYED,
	COLOR_NEUTRAL,
	COLOR_CHANGED
}

public enum BrickType {
	NONE = 0,
	NORMAL,
	POWERUP_BRICK,
	MID_LAYER
}

public class BricksManager : MonoBehaviour {
	public GameObject m_brick;
	// public BrickLayers[] m_brickLayers;
	public Transform m_brickContainer;
	public BrickType m_bricktype;
	public float m_startZ;
	public float m_startX;

	private int m_fieldHeight = 5;
	private int m_fieldWidth = 17;
	public string[ , ] m_playField;
	
	public BrickTracker m_midBrickTracker;


	public int GetFieldHeight {
		get { return m_fieldHeight; }
		set {}
	}

	public int GetFieldWidth {
		get { return m_fieldWidth; }
		set {}
	}

	// Use this for initialization
	void Start () {
		m_playField = new string[m_fieldHeight, m_fieldWidth];
		// m_brickGrid = new int[m_fieldHeight, m_fieldWidth];
		LevelStart();
		CreateLevel();
	}

	void LevelStart() {
		string block = "";
		for(int r = 0; r < m_fieldHeight; r++) {
			for (int c = 0; c < m_fieldWidth; c++) {
				switch (r) {					
					case 0:
						block = "C";
						break;

					case 1:
						block = "P";
						break;

					case 2:
						block = "W";
						break;

					case 3:
						block = "P";
						break;

					case 4:
						block = "C";
						break;
					
					default:
						block = " ";
						break;
				}

				m_playField[r, c] = block;
			}
		}
	
	}

	void CreateLevel() {
		GameObject tmpBrick;
		Vector3 tmpPos;

		tmpPos = Vector3.zero;

		for(float r = 0, z = m_startZ; r < m_fieldHeight; r++, z -= 4.5f) {
			for(float c = 0, x = m_startX; c < m_fieldWidth; c++, x += 7.5f) {
				if(m_playField[(int)r,(int)c] != " ") {
					tmpPos.x = c + x;
					tmpPos.y = 1.5f;
					tmpPos.z = z;
					tmpBrick = Instantiate(m_brick, tmpPos, Quaternion.identity);
					tmpBrick.GetComponent<BrickController>().m_gridLocationR = (int)r;
					tmpBrick.GetComponent<BrickController>().m_gridLocationC = (int)c;
					// m_midBrickTracker.m_brickGrid[(int)r,(int)c] = 1; 
					GetComponent<BrickTracker>().m_brickGrid[(int)r, (int)c] = 1;
					tmpBrick.transform.Rotate(0, 90, 0);
					tmpBrick.name = "Brick";
					tmpBrick.transform.parent = m_brickContainer;
					GetBrickType(tmpBrick, (int) r, (int)c);
				}
			}
		}
	}

	private BrickType GetBrickType(GameObject tmpObj, int r, int c) {
		BrickType retBrick = BrickType.NONE;

		switch(m_playField[r,c]) {
			case "W":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.white;
				tmpObj.tag = "MidBrick";
				retBrick = tmpObj.GetComponent<BrickController>().m_brickType = BrickType.MID_LAYER;
				break;

			case "P":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.green;
				retBrick = tmpObj.GetComponent<BrickController>().m_brickType = BrickType.NORMAL;
				break;

			case "C":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.yellow;
				retBrick = tmpObj.GetComponent<BrickController>().m_brickType = BrickType.NORMAL;
				break;
		}
		return retBrick;
	}

	public int BrickCountCheck() {
		return m_midBrickTracker.GetBrickCount();
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.O)){
			dBugField();
		}
	}

	// dBugging
	private void dBugField() {
		string outS = "";
		for(int r = 0; r < m_fieldHeight; r++) {
			for(int c = 0; c < m_fieldWidth; c++) {
				outS += "[" + m_playField[r, c] + "]";
			}
			outS += "\n";
		}

		outS += "\n";

		for(int r = 0; r < m_fieldHeight; r++) {
			for(int c = 0; c < m_fieldWidth; c++) {
				outS += "[" + GetComponent<BrickTracker>().m_brickGrid[r, c] + "]";
			}
			outS += "\n";
		}
		Debug.Log(outS);
	}
}
