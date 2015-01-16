using UnityEngine;
using System.Collections;

public class TeleportSlabManager : MonoBehaviour {
	public enum TeleporterTypes{RECEIVER, SENDER};
	public TeleporterTypes T_Type;
	public int adress;
	public bool hasTwin;
	private GameObject Twin;
	// Use this for initialization
	void Start () {
		hasTwin = false;
		GameObject[] Teleporters = GameObject.FindGameObjectsWithTag("TeleporterSlab");
		for(int i = 0; i < Teleporters.Length; i++){
			TeleportSlabManager teleporterManager = Teleporters[i].GetComponent<TeleportSlabManager>();
			if(teleporterManager.adress == adress && teleporterManager.T_Type != T_Type){
				hasTwin = true;
				Twin = Teleporters[i];
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Move(GameObject Cube)
	{
		if(!hasTwin){Cube.GetComponent<BasicMoves>().Move();}
		else {
			if(T_Type == TeleporterTypes.SENDER){
				Cube.GetComponent<TeleportMoves>().Send(Twin.transform.position);
			}
			else{
				Cube.GetComponent<BasicMoves>().Move();
			}
		}
	}

	void OnMetronomeEnd(GameObject Cube)
	{
		if(!hasTwin){Cube.GetComponent<BasicMoves>().EndMetronome();}
		else if(T_Type == TeleporterTypes.RECEIVER){
			Cube.GetComponent<TeleportMoves>().EndMetronome();
		}
	}
}
