using UnityEngine;
using System.Collections;

public class MainMetronome : MonoBehaviour {
	public float duration;
	public float ratio;
	public bool ended;
	public bool freeze;
	private float _elapsedTime;
	// Use this for initialization
	void Start () {
		freeze = false;
	}
	
	// Update is called once per frame
	void Update () {
		_elapsedTime += Time.deltaTime;
		ratio = _elapsedTime / duration;
		if(ended == true)
		{
			ended = false;
		}
		if(_elapsedTime >= duration)
		{
			ended = true;
			_elapsedTime = 0;
		}
	}
}
