using UnityEngine;

public enum BrickTypes { NONE = 0, WHITE = 50, ORANGE = 60, CYAN = 70, GREEN = 80, RED = 90, BLUE = 100, MAGENTA = 110, YELLOW = 120, SILVER = 130 , BLACK = 140}

public class LevelManager : MonoBehaviour {

	public GameObject m_brickPrefab;
	public Transform m_brickContainer;
	public float startZ;

	private Vector3 m_startPoint = new Vector3 (222.675f, 0.15f, -9.75f);


	private const int m_fieldHeight = 19;
	private const int m_fieldWidth = 13;
	private string[,] m_playField;


	void Start () {
		m_playField = new string[m_fieldHeight,m_fieldWidth];
		LoadLevel();
		CreateLevel();
	}

	private void LoadLevel() {

		string block = "";
		for(int r = 0; r < m_fieldHeight; r++) {
			for(int c = 0; c < m_fieldWidth; c++) {

				switch(r) {
					case 7:
						block = "Y"; // Grey
						break;

					case 8:
						block = "G"; // Red
						break;

					case 9:
						block = "W"; // Yellow
						break;

					case 10:
						block = "G"; // Cyan
						break;

					case 11:
						block = "Y"; // Magenta
						break;

					// case 18:
					// 	block = "E"; // Green
					// 	break;

					default:
						block = "K";
						break;
				}

				m_playField[r, c] = block;
			}
		}
	}

	private void CreateLevel() {
		GameObject tmpBrick;
		Vector3 tmpPos;

		tmpPos = Vector3.zero;

		for(float r = 0, z = startZ; r < m_fieldHeight; r++, z -= 0.5f) {
			for(int c = 0; c < m_fieldWidth; c++) {

				if(m_playField[(int)r,c] != " ") {
					tmpPos.x = c + 1;
					tmpPos.z = z;
					tmpBrick = Instantiate(m_brickPrefab, tmpPos, Quaternion.identity);
					tmpBrick.name = "Brick";
					tmpBrick.transform.parent = m_brickContainer;
					GetBrickType(tmpBrick, (int)r, c);
				}
			}
		}

		// m_brickContainer.position = m_startPoint;
	}

	private BrickTypes GetBrickType(GameObject tmpObj, int r, int c) {
		BrickTypes retBrick = BrickTypes.NONE;

		switch (m_playField[r, c]) {
			case "E":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.grey;
				retBrick = BrickTypes.SILVER;
				break;

			case "R":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.red;
				retBrick = BrickTypes.RED;
				break;

			case "Y":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.yellow;
				retBrick = BrickTypes.YELLOW;
				break;

			case "C":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.cyan;
				retBrick = BrickTypes.CYAN;
				break;

			case "M":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.magenta;
				retBrick = BrickTypes.MAGENTA;
				break;

			case "G":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.green;
				retBrick = BrickTypes.GREEN;
				break;

			case "W":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.white;
				retBrick = BrickTypes.WHITE;
				break;

			case "K":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.black;
				retBrick = BrickTypes.BLACK;
				break;
		}

		return retBrick;
	}



	
	// Update is called once per frame
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
		Debug.Log(outS);
	}


}
