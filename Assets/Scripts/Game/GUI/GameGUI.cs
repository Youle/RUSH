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

		EditModeManager.Start();
	}
	void Update(){
		if (Input.GetAxis("Mouse ScrollWheel") > 0){
			EditModeManager.IncrementSelected();
		}
		else if(Input.GetAxis("Mouse ScrollWheel") < 0){
			EditModeManager.DecrementSelected();
		}
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

		GameDatas datas = GameObject.FindGameObjectWithTag("GameDatas").GetComponent<GameDatas>();

		for(int i = 0; i < datas.SceneEnabledSlabs.Length; i++)
		{
			int marginTop = (i == EditModeManager.selected) ? 20 : 0;
			if(GUI.Button(new Rect(i * 110, marginTop, 100, 15), datas.SceneEnabledSlabs[i].name)){
				EditModeManager.selected = i;
			}
		}
	}
}
