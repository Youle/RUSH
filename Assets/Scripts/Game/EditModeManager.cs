using UnityEngine;
using System.Collections;

public class EditModeManager : MonoBehaviour {
	public static GameObject SelectedStageSet;
	public static int[] nbSlabs;
	public static GameObject[] Slabs;
	// Use this for initialization
	void Start () {
		nbSlabs = new int[4];
		Slabs = new GameObject[4];

		InstantiateSlabs();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void changeSelectedStageSet(GameObject Selected){
		if(SelectedStageSet != null)
		{
			UnSelectStageSet();
		}
		SelectStageSet(Selected);
	}

	public static void UnSelectStageSet(){
//		SelectedStageSet.renderer.material.color = new Color(255, 255, 255);
		SelectedStageSet = null;
	}

	public static void SelectStageSet(GameObject Selected){
		SelectedStageSet = Selected;
//		SelectedStageSet.renderer.material.color = new Color(0, 0, 0);
	}

	public static void InstantiateSlabs(){
		
		//for(int i = 0; i < nbSlabs.length)
	}
}
