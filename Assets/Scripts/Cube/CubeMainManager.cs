using UnityEngine;
using System.Collections;

public class CubeMainManager : MonoBehaviour {
	private GameObject Below;
	private GameObject Wall;
	public MainMetronome metronome;
	public Vector3 positionReference;
	public Vector3 directionReference;
	public float rot;
	// Use this for initialization
	void Start () {
		metronome = GameObject.FindGameObjectWithTag("metronome").GetComponent<MainMetronome>();
		positionReference = transform.position;
		directionReference = transform.forward;
		rot = transform.eulerAngles.y + 90;
		ManageEndMetronome();
	}
	
	// Update is called once per frame
	void Update () {
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
			else{
				//Fall();
			}
		}
	}
	void ManageEndMetronome()
	{
		if(Wall != null)
		{
			Debug.Log("Not Null");
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
}
