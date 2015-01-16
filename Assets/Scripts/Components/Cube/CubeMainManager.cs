using UnityEngine;
using System.Collections;

public class CubeMainManager : MonoBehaviour {
	private GameObject Below;
	private GameObject Wall;
	public static bool hasToDie;
	public MainMetronome metronome;
	public Vector3 positionReference;
	public Vector3 directionReference;
	public bool spawning;
	public float rot;
	private int fallCounter;
	// Use this for initialization
	void Start () {
		fallCounter = 0;
		spawning = true;
		metronome = GameObject.FindGameObjectWithTag("metronome").GetComponent<MainMetronome>();
		positionReference = transform.position;
		directionReference = transform.forward;
		rot = transform.eulerAngles.y + 90;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameStateHandler._STATE == GameStateHandler._STATES.RUN)
		{
			if(metronome.ended)
			{
				ManageEndMetronome(); 
			}

			else{
				if(Wall != null)
				{
					GetComponent<TookWallMoves>().Move();
				}
				if(Below != null)
				{
					Below.GetComponent<BelowManager>().moveManager(transform.gameObject);
				}
				else if(spawning == true)
				{
					GetComponent<SpawnMoves>().Move();
				}
				else{
					GetComponent<FallMoves>().Move();
				}
			}
		}
		else if(GameStateHandler._STATE == GameStateHandler._STATES.RESET){
			GetComponent<DieMoves>().Move();
		}
	}
	void ManageEndMetronome()
	{
		spawning = false;
		if(Wall != null){
			Wall = null;
			GetComponent<TookWallMoves>().ManageEndMetronome();
		}
		else
		{
			Below = checkSlab(false);
			if(Below != null)
			{
				Below.GetComponent<BelowManager>().changeStateManager(transform.gameObject);
				Wall = checkWall();
				if(Wall != null)
				{
					if(directionReference + positionReference == Wall.transform.position)
					{
						Below = null;
					}
					else{
						Wall = null;
					}
				}
			}

			else{
				GetComponent<FallMoves>().EndMetronome();
				fallCounter++;
				if(fallCounter == 4 && checkSlab(true) == null){
					//Game Over
				}
			}
		}

	}

	GameObject checkSlab(bool infiniteDistance){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, Vector3.down, out hit) && (infiniteDistance || hit.distance < 1) && hit.transform.name != "coloredCube"){
			return hit.transform.gameObject;
		}
		else
		{
			return null;
		}
	}

	GameObject checkWall(){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, directionReference, out hit) && hit.distance < 1 && hit.transform.name == "stageSet")
		{
			return hit.transform.gameObject;
		}
		else{
			return null;
		}
	}

	public void setBelow(GameObject toSet){
		Below = toSet;
	}

	public static void KillYourSelf(){
		hasToDie = true;
	}

	public void Delete(){
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "ColoredCube")
		{
			// Game OVER !
		}
	}
}
