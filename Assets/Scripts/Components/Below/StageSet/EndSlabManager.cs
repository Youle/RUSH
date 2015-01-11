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
	
	// Update is called once per frame
	void Update () {
		
	}

	void Move(GameObject Cube)
	{
		Cube.GetComponent<DispawnMoves>().Move();
	}

	void OnMetronomeEnd(GameObject Cube)
	{
		if(toDestroy)
		{
			Destroy(Cube);
		}
		toDestroy = !toDestroy;
	}

	public void Reset(){
		
	}
}
