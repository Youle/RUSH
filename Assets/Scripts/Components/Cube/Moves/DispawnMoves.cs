using UnityEngine;
using System.Collections;

public class DispawnMoves : MonoBehaviour {
	public AnimationCurve dispawnAnimationCurve;
	private CubeMainManager mainManager;
	private float metronomeRatio;
	private Vector3 positionReference;
	void Start()
	{
		mainManager = GetComponent<CubeMainManager>();
		positionReference = mainManager.positionReference;
	}
	public void Move(){
		metronomeRatio = mainManager.metronome.ratio;
		transform.localScale = new Vector3(1 - metronomeRatio, 1 - Mathf.Sin(metronomeRatio), 1 - Mathf.Sin(metronomeRatio));
	}
}
