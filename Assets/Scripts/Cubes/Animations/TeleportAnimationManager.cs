using UnityEngine;
using System.Collections;

public class TeleportAnimationManager : MonoBehaviour {
	public AnimationCurve teleportCurve;

	public void Move(float metronomeRatio, Vector3 positionReference, Vector3 receiverPosition)
	{
		if(metronomeRatio < 0.5)
		{
			float scale = 1 - teleportCurve.Evaluate(metronomeRatio * 2);
			transform.localScale = new Vector3(scale, scale, scale);
		}
		else
		{
			transform.position = new Vector3(receiverPosition.x, receiverPosition.y + 0.5f, receiverPosition.z);
			float scale = teleportCurve.Evaluate((metronomeRatio * 2) - 0.5f);
			transform.localScale = new Vector3(scale, scale, scale);
		}
	}
}
