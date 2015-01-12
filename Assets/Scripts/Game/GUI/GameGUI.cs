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
	// Use this for initialization
	void Start () {
		enabled = true;
		firstPhase = true;
		margin = 20;
		width = 200;
		height = 30;
		setBtnText();
	}
	
	void setBtnText()
	{
		runBtnText = runBtnStates[firstPhase ? 0 : 1];
	}

	void OnGUI(){
		if(GameStateHandler._STATE != GameStateHandler._STATES.RESET)
		{
			if(GUI.Button(new Rect(0 + margin, Screen.height - margin - height, width, height), runBtnText))
			{
				firstPhase = !firstPhase;
				GameStateHandler.UIClick(firstPhase);
				setBtnText();
			}
		}
	}
}
