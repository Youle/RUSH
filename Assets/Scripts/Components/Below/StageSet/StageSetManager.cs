using UnityEngine;
using System.Collections;

public class StageSetManager : BelowManager {
	public AnimationCurve WalkCurve;
	private float metronomeRatio;
	private GameObject Slab;
	private bool occupied;
	// Use this for initialization
	void Start () {
		occupied = false;
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
		if((GameStateHandler._STATE == GameStateHandler._STATES.EDIT && gameObject != EditModeManager.SelectedStageSet) && EditModeManager.allStageSetPlaced == false){
			EditModeManager.changeSelectedStageSet(gameObject);
		}
	}

	public void SetSlab(GameObject Slab){
		if(occupied){
			return;
		}
		occupied = true;
		GameObject SlabToPlace = Slab;
		SlabToPlace.tag = "PlacedSlab";
		SlabToPlace.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
		SlabToPlace.GetComponent<EditModeSlabManager>().stageSet = gameObject;
		Instantiate(SlabToPlace);
	}

	public void Clear(){
		occupied = false;
	}
}
