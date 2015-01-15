using UnityEngine;
using System.Collections;

public class StageSetManager : BelowManager {
	public AnimationCurve WalkCurve;
	private float metronomeRatio;
	// Use this for initialization
	void Start () {
	}

	public void Move(GameObject Cube)
	{
		Cube.GetComponent<BasicMoves>().Move();
	}

	public void Rotate(GameObject Cube)
	{
		Cube.GetComponent<BasicMoves>().Rotate();
	}

	void OnMetronomeEnd(GameObject Cube)
	{
		Cube.GetComponent<BasicMoves>().EndMetronome();
	}

	void OnMouseOver(){
		if(GameStateHandler._STATE == GameStateHandler._STATES.EDIT && gameObject != EditModeManager.SelectedStageSet){
			EditModeManager.changeSelectedStageSet(gameObject);
		}
	}
}
