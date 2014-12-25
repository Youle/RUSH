using UnityEngine;
using System.Collections;

public class SkyBoxCube : MonoBehaviour {
	public Material materialP;

	// Use this for initialization
	void Start () {
		transform.LookAt(new Vector3(0, transform.position.y, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
