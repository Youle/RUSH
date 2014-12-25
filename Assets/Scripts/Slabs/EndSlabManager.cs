using UnityEngine;
using System.Collections;

public class EndSlabManager : MonoBehaviour {
	public Material materialReference;
	public float nbCubes;
	void Start () {
		renderer.material.color = materialReference.color;
		nbCubes = 0;
	}
}
