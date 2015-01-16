using UnityEngine;
using System.Collections;

public class EditModeManager : MonoBehaviour {
	public static GameObject SelectedStageSet;
	public static int[] nbSlabs;
	public static GameObject[] Slabs;
	public static GameDatas gameDatas;
	public static GameObject Slab;
	public static int selected;
	// Use this for initialization
	public static void Start () {
		gameDatas = GameObject.FindGameObjectWithTag("GameDatas").GetComponent<GameDatas>();
		nbSlabs = gameDatas.nbOfEachSlab;
		Slabs = gameDatas.SceneEnabledSlabs;
		selected = 0;
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
		SelectedStageSet = null;
		DestroyHoverObject();
	}

	public static void SelectStageSet(GameObject newStageSet){
		SelectedStageSet = newStageSet;
		if(Slab != null)
		{
			DestroyHoverObject();
		}

		Slab = Slabs[selected];
		Slab.gameObject.transform.position = new Vector3(SelectedStageSet.transform.position.x, SelectedStageSet.transform.position.y + 0.8f, SelectedStageSet.transform.position.z);
		Slab.tag = "CloneSlab";
		Instantiate(Slab);
//		InstantiateSlab();
	}
	public static void DestroyHoverObject()
	{
		GameObject[] ToDestroy = GameObject.FindGameObjectsWithTag("CloneSlab");	
		for(int i = 0 ; i < ToDestroy.Length; i++){
			Destroy(ToDestroy[i].gameObject);
		}	
	}
	public static void InstantiateSlab(){
	}

	public static void IncrementSelected(){
		selected = (selected >= Slabs.Length - 1) ? 0 : selected + 1;
	}

	public static void DecrementSelected(){
		selected = (selected <= 0) ? Slabs.Length - 1 : selected - 1;
	}

	public static void PlaceSlab(){
		SelectedStageSet.GetComponent<StageSetManager>().SetSlab(Slab);
		DestroyHoverObject();
	}

	public static void RemoveSlab(){

	}
}
