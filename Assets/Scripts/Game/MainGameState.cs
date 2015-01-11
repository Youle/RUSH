using UnityEngine;
using System.Collections;

public class MainGameState : MonoBehaviour {
	private GameGUI gameGui;
	private MainMetronome metronome;
	private GameObject[] Cubes;
	// Use this for initialization
	void Start () {
		gameGui = GameObject.FindGameObjectWithTag("GameGui").GetComponent<GameGUI>();
		metronome = GameObject.FindGameObjectWithTag("metronome").GetComponent<MainMetronome>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ManageFreeze(bool hasToRestart){
		if(hasToRestart){
			Restart();
		}

		else{
			metronome.Unfreeze();
		}
	}

	void Restart(){
		GameGUI.enabled = false;
		metronome.Restart();
		DestroyCubes();
		ResetGenerators();
		ResetEndSlabs();
	}

	public static void hasRestarted(){
		GameGUI.enabled = true;
	}

	void DestroyCubes(){
		CubeMainManager.hasToDie = true;
	}

	void ResetGenerators(){
		GameObject[] Generators = GameObject.FindGameObjectsWithTag("Generator");

		foreach(GameObject Generator in Generators)
		{
			Generator.GetComponent<GeneratorManager>().Reset();
		}
	}

	void ResetEndSlabs(){
		GameObject[] EndSlabs = GameObject.FindGameObjectsWithTag("EndSlab");

		foreach(GameObject EndSlab in EndSlabs)
		{
			EndSlab.GetComponent<EndSlabManager>().Reset();
		}
	}
}
