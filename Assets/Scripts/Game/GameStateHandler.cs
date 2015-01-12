using UnityEngine;
using System.Collections;

public class GameStateHandler : MonoBehaviour {
	public enum _STATES{PAUSED, EDIT, RUN, RESET, WIN, LOOSE};
	public static _STATES _STATE;
	
	public static void Init(){
		_STATE = _STATES.EDIT;
	}

	public static void UIClick(bool hasToRestart){
		if(hasToRestart == true)
		{
			_STATE = _STATES.RESET;
		}
		else{
			_STATE = _STATES.RUN;
		}
	}

	public static void AskForRestart(){
		if(checkIfIsLastCube())
		{
			_STATE = _STATES.EDIT;
		}
	}

	static bool checkIfIsLastCube(){
		GameObject[] Cubes = GameObject.FindGameObjectsWithTag("ColoredCube");
		return (Cubes.Length <= 1);
	}
}
