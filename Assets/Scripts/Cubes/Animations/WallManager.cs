using UnityEngine;
using System.Collections;

public class WallManager : MonoBehaviour {
	public AnimationCurve WallCurve;

	public void Move(float metronomeRatio, Vector3 positionReference, Vector3 directionReference)
	{
		// Shit le cube ne tourne pas en fait !
		Vector3 direction = new Vector3(directionReference.z, 0, directionReference.x);
		transform.eulerAngles = new Vector3(direction.x * -WallCurve.Evaluate(metronomeRatio) * 720, transform.eulerAngles.y, direction.z * -WallCurve.Evaluate(metronomeRatio) * 720);
	}
}
