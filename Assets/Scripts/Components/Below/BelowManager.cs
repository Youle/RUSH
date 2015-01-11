using UnityEngine;
using System.Collections;

public class BelowManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeStateManager(GameObject Cube){
		BroadcastMessage("OnMetronomeEnd", Cube);
	}

	public void moveManager(GameObject Cube){
		SendMessage("Move", Cube);
	}
}
