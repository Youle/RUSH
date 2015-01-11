using UnityEngine;
using System.Collections;

public class ConveyorMoves : MonoBehaviour {
	private Vector3 positionReference;
	private float metronomeRatio;

	public void Move(Vector3 conveyorDirection) {
		positionReference = GetComponent<CubeMainManager>().positionReference;
		metronomeRatio = GetComponent<CubeMainManager>().metronome.ratio;
		transform.position = new Vector3(positionReference.x + conveyorDirection.x * metronomeRatio, positionReference.y, positionReference.z + conveyorDirection.z * metronomeRatio);
	}
}
