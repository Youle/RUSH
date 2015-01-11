using UnityEngine;
using System.Collections;

public class SpawnMoves : MonoBehaviour {
	public AnimationCurve spawnAnimationCurve;
	private CubeMainManager mainManager;
	private Vector3 positionReference;
	private float metronomeRatio;
	void Start()
	{
		mainManager = GetComponent<CubeMainManager>();
		positionReference = mainManager.positionReference;
	}
	public void Move(){
		metronomeRatio = mainManager.metronome.ratio;
		transform.position = new Vector3(transform.position.x, positionReference.y + spawnAnimationCurve.Evaluate(metronomeRatio), transform.position.z);
	}
}
