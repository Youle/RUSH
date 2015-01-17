using UnityEngine;
using System.Collections;

public class GameDatas : MonoBehaviour {
	public GameObject[] SceneEnabledSlabs;
	public int[] nbOfEachSlab;
	public static int cubesToRelease;
	public static void AddCubesToRelease(int cubesToAdd){
		cubesToRelease += cubesToAdd;
	}
}
