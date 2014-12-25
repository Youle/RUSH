using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

	private MainManager _mainManager;
	// Use this for initialization
	void Start () {
		_mainManager = gameObject.GetComponent<MainManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Left()
	{
		_mainManager._rot -= 90;
		_mainManager.directionReference = new Vector3(-_mainManager.directionReference.z, 0, _mainManager.directionReference.x);
	}
	public void Right()
	{
		_mainManager._rot += 90;
		_mainManager.directionReference = new Vector3(_mainManager.directionReference.z, 0, -_mainManager.directionReference.x);
	}
	public void Clever(GameObject Slab)
	{
		_mainManager._rot = Slab.transform.eulerAngles.y;
		_mainManager.directionReference = Slab.transform.right;

	}
}
