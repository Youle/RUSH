using UnityEngine;
using System.Collections;

public class EndPartyTextManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameStateHandler._STATE == GameStateHandler._STATES.WIN)
		{
			guiText.text = "Victory";
		}
		else if(GameStateHandler._STATE == GameStateHandler._STATES.LOOSE)
		{
			guiText.text = "Try Again";	
		}
		else{
			guiText.text = "";
		}
	}
}
