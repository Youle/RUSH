using UnityEngine;
using System.Collections;
public class GameGUI : MonoBehaviour {
	public string[] runBtnStates = new [] {"PLAY", "RESET"};
	public string runBtnText;
	public bool firstPhase;
	public float margin;
	public float width;
	public float height;
	public static bool enabled;
	private MainGameState gameState;
	// Use this for initialization
	void Start () {
		enabled = true;
		firstPhase = true;
		margin = 20;
		width = 200;
		height = 30;
		setBtnText();
		gameState = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MainGameState>();
	}
	
	void setBtnText()
	{
		runBtnText = runBtnStates[firstPhase ? 0 : 1];
	}

	void OnGUI(){
		if(enabled)
		{
			if(GUI.Button(new Rect(0 + margin, Screen.height - margin - height, width, height), runBtnText))
			{
				firstPhase = !firstPhase;
				setBtnText();
				gameState.ManageFreeze(firstPhase);
			}
		}
	}
}
