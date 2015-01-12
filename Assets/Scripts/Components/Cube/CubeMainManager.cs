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
	// Use this for initialization
	void Start () {
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
					//Fall();
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
			Below = checkSlab();
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
		}

	}

	GameObject checkSlab(){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, Vector3.down, out hit) && hit.distance < 1){
			return hit.transform.gameObject;
		}
		else
		{
			return null;
		}
	}

	GameObject checkWall(){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, directionReference, out hit) && hit.distance < 1)
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
}
