using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {
	public bool spawning;
	public Vector3 positionReference;
	public Vector3 directionReference;
	public Vector3 parentDirection;
	public bool debug = false;
	public float _rot;
	public Material parentMaterial;

	private StateManager _stateManager;
	private MainMetronome _metronome;
	// Use this for initialization
	void Start () {
		_metronome = GameObject.FindGameObjectWithTag("metronome").GetComponent<MainMetronome>();
		_stateManager = gameObject.GetComponent<StateManager>();
		spawning = true;
		directionReference = Vector3.up;
		positionReference = transform.position;
		renderer.material.color = parentMaterial.color;
	}
	
	// Update is called once per frame
	void Update () {
		if(!_metronome.freeze)
		{
			_stateManager.Manage(_metronome.ratio, positionReference, directionReference, _rot);
			if(_metronome.ended)
			{
				manageEnd_metronome();
			}
		}
	}

	void manageEnd_metronome()
	{
		_stateManager.EndMetronome(directionReference);
		positionReference = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
		transform.position = positionReference;
		transform.rotation = Quaternion.identity;
	}

	public void SetData (Vector3 direction) {
		_rot = (direction == Vector3.forward) ? 270 :
				(direction == Vector3.right)  ? 0   :
				(direction == Vector3.back)   ? 90  :
											    180 ;
		directionReference = direction;
	}
}
