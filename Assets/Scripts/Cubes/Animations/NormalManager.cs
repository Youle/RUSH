using UnityEngine;
using System.Collections;

public class NormalManager : MonoBehaviour {
	public AnimationCurve WalkCurve;

	public void Move(float metronomeRatio, Vector3 positionReference, Vector3 directionReference, float _rot)
	{
		transform.position = positionReference + directionReference * metronomeRatio;
		transform.position = new Vector3(transform.position.x, transform.position.y * WalkCurve.Evaluate(metronomeRatio), transform.position.z);

		transform.rotation = Quaternion.Euler(0, _rot, -metronomeRatio * 90);
	}

	public void Slide(float metronomeRatio, Vector3 positionReference, Vector3 directionReference)
    {
    	transform.position = positionReference + directionReference * metronomeRatio;
    }
}
