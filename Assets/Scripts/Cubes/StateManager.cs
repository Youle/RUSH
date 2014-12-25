using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {
	public bool toStun = false;
	public string state;
	public float nbFallingBeforeLoose = 5;

	private SpawnManager             _spawnManager;
	private NormalManager            _normalManager;
	private TurnManager              _turnManager;
	private FallingManager           _fallingManager;
	private EndManager               _endManager;
	private GameManager              _gameManager;
	private WallManager              _wallManager;
	private TeleportAnimationManager _teleportAnimationManager;
	private float fallingCnt;
	private Vector3 teleportReference;

	private Vector3 conveyorVector;

	// Use this for initialization
	void Start () {
		state = "spawning";
		_spawnManager = gameObject.GetComponent<SpawnManager>();
		_normalManager = gameObject.GetComponent<NormalManager>();
		_turnManager = gameObject.GetComponent<TurnManager>();
		_fallingManager = gameObject.GetComponent<FallingManager>();
		_endManager = gameObject.GetComponent<EndManager>();
		_wallManager = gameObject.GetComponent<WallManager>();
		_teleportAnimationManager = gameObject.GetComponent<TeleportAnimationManager>();

		_gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
		fallingCnt = 0;
	}

	public void Manage(float metronomeRatio, Vector3 positionReference, Vector3 directionReference, float _rot)
	{
		switch(state)
		{
			case "spawning" : _spawnManager.move(metronomeRatio, positionReference, directionReference); break;
			case "normal" : _normalManager.Move(metronomeRatio, positionReference, directionReference, _rot); break;
			case "tookWall" : _wallManager.Move(metronomeRatio, positionReference, directionReference); break;
			case "sliding" : _normalManager.Slide(metronomeRatio, positionReference, conveyorVector); break;
			case "teleporting": _teleportAnimationManager.Move(metronomeRatio, positionReference, teleportReference); break;
			case "falling" : _fallingManager.Move(metronomeRatio, positionReference); break;
			case "end" : _endManager.Move(metronomeRatio); break;
			default: break;
		}
	}

	public void EndMetronome(Vector3 directionReference)
	{
		if(!checkWall(directionReference) && state != "spawning")
		{
			checkSlab();
		}
		switch(state)
		{
			case "spawning": state = "normal"; _spawnManager.manageEndSpawn(); break;
			case "turnRight" : _turnManager.Right(); state = "normal"; break;
			case "turnLeft" : _turnManager.Left(); state = "normal"; break;
			case "willSlide" : state = "sliding"; break;
			case "toStun" : state = "stun"; break;
			case "stun" : state = "normal"; break;
			case "willTeleport" :  state="teleporting"; break;
			case "teleporting" :  state="normal"; break;
			default: break;
		}
		fallingCnt = (state == "falling") ? fallingCnt + 1 : 0;
		if(fallingCnt > nbFallingBeforeLoose)
		{
			_gameManager.Loose();
		}
	}

	public void SlabManager(GameObject slab)
	{
		switch(slab.name)
		{
			case "TurnSlab" : _turnManager.Clever(slab); break;
			case "SplitSlab" : state = slab.GetComponent<SplitManager>().whichSide(); break;
			case "StopSlab" : state = (state != "stopped") ? "stopped" : "normal"; break;
			case "ConveyorSlab" : conveyorVector = slab.transform.right; state = "willSlide"; break;
			case "EndSlab" : manageEnd(slab); break;
			case "Teleporter" : Teleport(slab); break;
			default: state = (state == "sliding") ? "toStun" : "normal";break;
		}
	}

	void manageEnd(GameObject slab)
	{
		if(slab.renderer.material.color == gameObject.renderer.material.color){
			state = "end";
			_gameManager.cubeArrived();
		}
	}

	void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "cube")
        {
        	_gameManager.Loose();
        }
    }

    void Teleport(GameObject slab)
    {
    	if(slab.GetComponent<TeleporterManager>().getType() == "sender")
    	{
    		state = "willTeleport";
	    	teleportReference = slab.GetComponent<TeleporterManager>().getReceiverPosition(transform.position);		
    	}
    }
    bool checkWall(Vector3 directionReference){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, directionReference, out hit) && hit.distance < 1 && hit.transform.name == "stageSet"){
			state = (state == "tookWall") ? "turnRight" : "tookWall";
			return true;
		}
		return false;
	}

	void checkSlab(){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, Vector3.down, out hit) && hit.distance < 1){
			SlabManager(hit.transform.gameObject);
		}
		else
		{
			state = "falling";
		}
	}
}
