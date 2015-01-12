using UnityEngine;
using System.Collections;

public class GeneratorManager : MonoBehaviour {
	public int nbChildrenToCreate;
	public int nbTurnBetweenChildren;
	public GameObject Cube;
	public Material Color;
	private MainMetronome metronome;
	private int nbChildren = 0;
	private int nbTurnSinceLastChildren;
	// Use this for initialization
	void Start () {
		renderer.material = Color;
		nbChildren = 0;
		metronome = GameObject.FindGameObjectWithTag("metronome").GetComponent<MainMetronome>();
	}
	
	void createCube(){
		nbChildren += 1;
		Cube.renderer.material = Color;
		Cube.transform.position = transform.position;
		Cube.transform.eulerAngles = transform.eulerAngles;
		Instantiate(Cube);
		nbTurnSinceLastChildren = 0;
	}
	// Update is called once per frame
	void Update () {
		if(GameStateHandler._STATE == GameStateHandler._STATES.RUN){
			if(metronome.ended && nbChildren < nbChildrenToCreate)
			{
				nbTurnSinceLastChildren++;
				if(nbTurnSinceLastChildren == nbTurnBetweenChildren)
				{
					createCube();
				}
			}
		}
		else if(GameStateHandler._STATE == GameStateHandler._STATES.RESET){
			Reset();
		}
	}

	void Move(GameObject Cube)
	{
		Cube.GetComponent<BasicMoves>().Move();
	}

	void OnMetronomeEnd(GameObject Cube)
	{
		Cube.GetComponent<CubeMainManager>().spawning = false;
		Cube.GetComponent<BasicMoves>().EndMetronome();
	}

	public void Reset()
	{
		nbChildren = 0;
		nbTurnSinceLastChildren = 0;
	}
}
