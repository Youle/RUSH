using UnityEngine;
using System.Collections;

public class EndSlabManager : MonoBehaviour {
	public Material Color;
	private bool toDestroy;
	// Use this for initialization
	void Start () {
		toDestroy = false;
		renderer.material = Color;
	}

	void Move(GameObject Cube)
	{
		if(Cube.renderer.material.color == renderer.material.color){
			Cube.GetComponent<DispawnMoves>().Move();
		}
		else{
			Cube.GetComponent<BasicMoves>().Move();
		}
	}

	void OnMetronomeEnd(GameObject Cube)
	{
		if(Cube.renderer.material.color == renderer.material.color){
			if(toDestroy)
			{
				Destroy(Cube);
				GameStateHandler.CubeReleased();
			}
			toDestroy = !toDestroy;
		}
		else{
			Cube.GetComponent<BasicMoves>().EndMetronome();
		}
	}
}
