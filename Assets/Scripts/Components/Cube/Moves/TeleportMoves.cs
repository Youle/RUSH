using UnityEngine;
using System.Collections;

public class TeleportMoves : MonoBehaviour {
	private CubeMainManager mainManager;
	private float metronomeRatio;
	// Use this for initialization
	void Start () {
		mainManager = GetComponent<CubeMainManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Send(Vector3 whereToGo){
		metronomeRatio = mainManager.metronome.ratio;
		transform.localScale = new Vector3(1 - metronomeRatio, 1 - metronomeRatio, 1 - metronomeRatio);
		if(metronomeRatio > 0.9f){
			transform.position = new Vector3(whereToGo.x, whereToGo.y + 0.5f, whereToGo.z);	
		}
	}

	public void EndMetronome(){
		transform.localScale = new Vector3(1, 1, 1);
		GetComponent<BasicMoves>().EndMetronome();
	}
}
