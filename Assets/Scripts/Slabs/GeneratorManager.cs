using UnityEngine;
using System.Collections;

public class GeneratorManager : MonoBehaviour {
	public float nbChildren;
	public float nbMetronomeBetweenSpawn;
	public Material materialReference;
	public GameObject cube;
	public Vector3 direction;
	
	private float _releasedCube;
	private float _nbMetronomeEnded;
	private MainMetronome _metronome;
	private float decalY = 0.2f;
	// Use this for initialization
	void Start () {
		_releasedCube = 0;
		_nbMetronomeEnded = 0;
		_metronome = GameObject.FindGameObjectWithTag("metronome").GetComponent<MainMetronome>();
		transform.position = new Vector3(transform.position.x, transform.position.y + decalY, transform.position.z);
        renderer.material.color = materialReference.color;
	}
	
	// Update is called once per frame
	void Update () {
		if(_metronome.ended && nbChildren - _releasedCube > 0 && !_metronome.freeze)
		{
			_nbMetronomeEnded++;
			if(_nbMetronomeEnded % nbMetronomeBetweenSpawn == 0)
			{
				manageCubeSpawn();
			}
		}
	}
	
	void manageCubeSpawn(){
		createACube();
		_releasedCube++;
		_nbMetronomeEnded = 0;
	}

	void createACube()
	{
		cube.GetComponent<MainManager>().parentMaterial = materialReference;
		cube.GetComponent<SpawnManager>().parentDirection = direction;
		Instantiate(cube, new Vector3(transform.position.x, transform.position.y - decalY,transform.position.z), Quaternion.identity);
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().nbCubes++;
	}
}
