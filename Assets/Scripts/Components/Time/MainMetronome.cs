using UnityEngine;
using System.Collections;
public class MainMetronome : MonoBehaviour {
	public float duration;
	public float ratio;
	public bool ended;
	public bool freezed;
	public bool hasToRestart;
	private float _elapsedTime;
	// Use this for initialization
	void Start () {
		freezed = true;
		ratio = 0;
		_elapsedTime = 0;
		GameStateHandler.Init();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameStateHandler._STATE == GameStateHandler._STATES.RUN)
		{
			Play();
		}
		else if(GameStateHandler._STATE == GameStateHandler._STATES.RESET){
			GameStateHandler.AskForRestart();
		}
	}
	
	void Play()
	{
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

	public void Restart(){
		hasToRestart = true;
		Start();
	}

	void Freeze(){
		freezed = true;
	}

	public void Unfreeze(){
		freezed = false;
	}
}
