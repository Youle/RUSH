using UnityEngine;
using System.Collections;

public class BasicMoves : MonoBehaviour {
	private CubeMainManager mainManager;
	private float metronomeRatio;

	public AnimationCurve BasicMoveCurve;
	// Use this for initialization
	void Start () {
		mainManager = GetComponent<CubeMainManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move()
	{
		metronomeRatio = mainManager.metronome.ratio;
		float PositionX = mainManager.positionReference.x + mainManager.directionReference.x * metronomeRatio;
		float PositionY = mainManager.positionReference.y + BasicMoveCurve.Evaluate(metronomeRatio);
		float PositionZ = mainManager.positionReference.z + mainManager.directionReference.z * metronomeRatio;
		transform.position = new Vector3(PositionX, PositionY, PositionZ);

		Rotate();
	}

	public void Rotate()
	{
		metronomeRatio = mainManager.metronome.ratio;
		transform.rotation = Quaternion.Euler(0, mainManager.rot, metronomeRatio * 90);
	}

	public void EndMetronome()
	{
		transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
		mainManager.positionReference = transform.position;
	}
}
