using UnityEngine;
using System.Collections;

public class GameStateHandler : MonoBehaviour {
	public enum _STATES{PAUSED, EDIT, RUN, RESET, WIN, LOOSE};
	public static _STATES _STATE;
	public static int cubesReleased;
	
	public static void Init(){
		_STATE = _STATES.EDIT;
		cubesReleased = 0;
	}

	public static void UIClick(bool hasToRestart){
		if(hasToRestart == true)
		{
			_STATE = _STATES.RESET;
		}
		else{
			_STATE = _STATES.RUN;
			EditModeManager.UnSelectStageSet();
		}
	}

	public static void AskForRestart(){
		if(checkIfIsLastCube())
		{
			_STATE = _STATES.EDIT;
			cubesReleased = 0;
		}
	}

	static bool checkIfIsLastCube(){
		GameObject[] Cubes = GameObject.FindGameObjectsWithTag("ColoredCube");
		return (Cubes.Length <= 1);
	}

	public static void GameOver(){
		_STATE = _STATES.LOOSE;
	}

	public static void Victory(){
		_STATE = _STATES.WIN;
		Debug.Log("Victory");
	}

	public static void CubeReleased(){
		cubesReleased++;
		if(cubesReleased == GameDatas.cubesToRelease){
			Victory();
		}
	}
}
