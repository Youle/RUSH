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

	public GUIStyle customButton;
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
			if(GameStateHandler._STATE == GameStateHandler._STATES.WIN)
			{
				if(GUI.Button(new Rect(0 + margin, Screen.height - margin - height, width, height), "Retour au menu")){

				}
			}
			else{
				if(GUI.Button(new Rect(0 + margin, Screen.height - margin - height, width, height), runBtnText))
				{
					firstPhase = !firstPhase;
					GameStateHandler.UIClick(firstPhase);
					setBtnText();
				}
			}
		}

		for(int i = 0; i < EditModeManager.Slabs.Length; i++)
		{
			//GUISkin myGUISkin = Resources.Load("ButtonsSkin");
			Color thisColor = GUI.color;
			thisColor.a = (EditModeManager.nbSlabs[i] == 0) ? 0.5f : 1;
			GUI.color = thisColor;
			int marginTop = (i == EditModeManager.selected && EditModeManager.allStageSetPlaced == false) ? 20 : 0;
			if(GUI.Button(new Rect(i * 110, marginTop, 160, 15), EditModeManager.Slabs[i].name + " (" + EditModeManager.nbSlabs[i] + ")", customButton)){
				EditModeManager.selected = i;
			}
			if(EditModeManager.nbSlabs[i] == 0){
			}
		}
	}
}
