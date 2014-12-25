using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
	public AnimationCurve SpawnCurve;
	public Vector3 parentDirection;
	private MainManager _mainManager;
	// Use this for initialization
	void Start () {
		_mainManager = gameObject.GetComponent<MainManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void move(float ratio, Vector3 positionReference, Vector3 directionReference){
		transform.position = positionReference + directionReference * SpawnCurve.Evaluate(ratio);
	}

	public void manageEndSpawn()
	{
		_mainManager.SetData(parentDirection);
	}
}
