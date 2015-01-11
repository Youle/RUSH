using UnityEngine;
using System.Collections;

public class DieMoves : MonoBehaviour {
	private float metronomeRatio;
	public void Move(){
		transform.localScale = new Vector3(transform.localScale.x - 0.03f, transform.localScale.y - 0.03f, transform.localScale.z - 0.03f);
		transform.Rotate(Vector3.up, Time.deltaTime, Space.World);
		if(transform.localScale.x < 0.05)
		{
			Destroy(gameObject);
			CubeMainManager.hasToDie = false;
			MainGameState.hasRestarted();
		}
	}
}
