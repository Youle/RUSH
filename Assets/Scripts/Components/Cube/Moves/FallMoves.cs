using UnityEngine;
using System.Collections;

public class FallMoves : MonoBehaviour {
	private float metronomeRatio;
	private CubeMainManager mainManager;
	// Use this for initialization
	void Start () {
		mainManager = GetComponent<CubeMainManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move(){
		metronomeRatio = mainManager.metronome.ratio;
		transform.position = new Vector3(transform.position.x, mainManager.positionReference.y - metronomeRatio, transform.position.z);
	}

	public void EndMetronome(){
		GetComponent<BasicMoves>().EndMetronome();
	}
}
