using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public float nbCubes;
	public bool defeat;
	public bool won;

	private EndTextManager _endText;
	private MainMetronome _metronome;
	// Use this for initialization
	void Start () {
		defeat = false;
		won = false;
		nbCubes = 0;
		_metronome = GameObject.FindGameObjectWithTag("metronome").GetComponent<MainMetronome>();
		_endText = GameObject.FindGameObjectWithTag("EndText").GetComponent<EndTextManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void cubeArrived(){
		nbCubes--;
		if(nbCubes == 0)
		{
			Win();
		}
	}

	void Win()
	{
		_endText.Win();
		won = true;
	}

	public void Loose()
	{
		_endText.Loose();
		_metronome.freeze = true;
		defeat = true;
	}
}
