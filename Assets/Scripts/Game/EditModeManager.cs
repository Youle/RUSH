using UnityEngine;
using System.Collections;

public class EditModeManager : MonoBehaviour {
	public static GameObject SelectedStageSet;
	public static int[] nbSlabs;
	public static GameObject[] Slabs;
	public static GameDatas gameDatas;
	public static GameObject Slab;
	public static int selected;
	public static bool allStageSetPlaced;
	private static int preventSelectedWhileInfinite;
	// Use this for initialization
	public static void Start () {
		gameDatas = GameObject.FindGameObjectWithTag("GameDatas").GetComponent<GameDatas>();
		nbSlabs = gameDatas.nbOfEachSlab;
		Slabs = gameDatas.SceneEnabledSlabs;
		selected = 0;
		preventSelectedWhileInfinite = 0;
		allStageSetPlaced = false;
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
		Debug.Log(selected);
		selected = (selected >= Slabs.Length - 1) ? 0 : selected + 1;
		checkNewSelectedSlab();
	}

	public static void DecrementSelected(){
		selected = (selected <= 0) ? Slabs.Length - 1 : selected - 1;
		checkNewSelectedSlab();
	}

	static void checkNewSelectedSlab(){
		if(!StillSelectedSlab(selected))
		{
			preventSelectedWhileInfinite++;
			if(preventSelectedWhileInfinite > Slabs.Length){
				UnSelectStageSet();
				allStageSetPlaced = true;
			}
			else{
				IncrementSelected();
			}
		}
		else{
			preventSelectedWhileInfinite = 0;
		}
	}

	public static void PlaceSlab(){
		if(StillSelectedSlab(selected)){
			SelectedStageSet.GetComponent<StageSetManager>().SetSlab(Slab);
			DestroyHoverObject();
			nbSlabs[selected]--;
			if(!StillSelectedSlab(selected)){
				IncrementSelected();
			}
		}
	}

	static bool StillSelectedSlab(int toCheck){
		if(nbSlabs[toCheck] > 0){
			return true;
		}
		return false;
	}

	public static void RemoveSlab(string SlabName){
		for(int i = 0; i < Slabs.Length; i++)
		{
			Debug.Log(SlabName);
			Debug.Log(Slabs[i].name);
			if(Slabs[i].name + "(Clone)" == SlabName){
				nbSlabs[i]++;
				if(allStageSetPlaced){
					allStageSetPlaced = false;
					preventSelectedWhileInfinite = 0;
					selected = i;
				}
			}
		}
	}
}
