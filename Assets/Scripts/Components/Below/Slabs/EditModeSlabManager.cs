using UnityEngine;
using System.Collections;

public class EditModeSlabManager : MonoBehaviour {
	public GameObject stageSet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameStateHandler._STATE == GameStateHandler._STATES.EDIT){
			if(Input.GetMouseButtonDown(0)){
				
			}

			if(Input.GetMouseButtonDown(1)){
			}
		}
	}

	void OnMouseOver () 
	{
		if(gameObject.tag == "PlaceSlab")
		{
			EditModeManager.DestroyHoverObject();
		}
		if(GameStateHandler._STATE == GameStateHandler._STATES.EDIT){
		    if(Input.GetMouseButtonUp(0)){
		    	EditModeManager.PlaceSlab();
		    }
		    if(Input.GetMouseButtonUp(1)){
				EditModeManager.RemoveSlab(transform.name);
				stageSet.GetComponent<StageSetManager>().Clear();
				Destroy(gameObject);
	    	}
	    }
	}
}
