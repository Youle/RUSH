using UnityEngine;
using System.Collections;
using MathTools;
public class SkyBox : MonoBehaviour {
	// Use this for initialization
	public GameObject skyboxCube;
	private float _radius;
	private float _perimeter;
	private float _nbCubesPerimeter;
	void Start () {
		_radius = 12;
		_perimeter = calculatePerimeter(_radius);
		_nbCubesPerimeter = Mathf.Round(_perimeter / 2);

		drawSkybox();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime);
	}
	float calculatePerimeter(float radius)
	{
		return 2 * Mathf.PI * radius;
	}
	void drawSkybox()
	{
		for(int i = 0; i < _nbCubesPerimeter; i++)
		{
			float high = Random.Range(5, 8);
			for(int j = 0; j < high; j++)
			{
				CoordSystem.Cylindrical cylCoord = new CoordSystem.Cylindrical (_radius, 2 * Mathf.PI * (float) i / _nbCubesPerimeter, j * 2);
				GameObject skyCube = Instantiate(skyboxCube, CoordSystem.CylindricToCartesian(cylCoord), Quaternion.identity) as GameObject;
				skyCube.transform.parent = transform;
			}
		}
	}
}
