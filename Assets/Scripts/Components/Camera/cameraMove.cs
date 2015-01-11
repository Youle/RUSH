using UnityEngine;
using System.Collections;
using MathTools;
public class cameraMove : MonoBehaviour {
	public float radius = 8.13f;
	public float theta = 1.6f;
	public float phi = 2.06f;
	public float horizontalRatio = 0.5f;
	public float verticalRatio = 0.5f;
	public float minphi = 0.2f;
	public float maxphi = 0.79f;
	public float ratioMouseMove;

	private Vector3 _difMouse;
	private bool _lookAtMousePosition;
	private CoordSystem.Spherical _sphCoord;

	void Start () {
		_sphCoord = new CoordSystem.Spherical (radius, theta, phi);
		transform.position = CoordSystem.SphericalToCartesian (_sphCoord);
	}
	
	void Update () {
		_sphCoord = new CoordSystem.Spherical (radius, theta, phi);
		transform.position = CoordSystem.SphericalToCartesian (_sphCoord);
		transform.LookAt(Vector3.zero);
		if(!manageMouse())
		{
			theta += Input.GetAxis("Horizontal") / horizontalRatio;
			phi = Mathf.Clamp(phi + (-Input.GetAxis("Vertical") / verticalRatio), minphi, maxphi);
		}
	}
	Vector3 moveCameraWithMouse()
	{
		Vector3 newMouse = Input.mousePosition;
		if(_difMouse == new Vector3(0, 0, 0))
		{
			_difMouse = newMouse;
		}
		float x = (_difMouse.x - newMouse.x) / (Screen.width * ratioMouseMove);
		float y = (_difMouse.y - newMouse.y) / (Screen.height * ratioMouseMove);
		_difMouse = newMouse;
		return new Vector3(x, y, 0);
	}
	bool manageMouse()
	{
		if(Input.GetMouseButtonDown(1))
		{
			_lookAtMousePosition = true;
		}
		if(Input.GetMouseButtonUp(1))
		{
			_lookAtMousePosition = false;
			_difMouse = new Vector3(0, 0, 0);
		}
		if(_lookAtMousePosition)
		{
			Vector3 cameraRelativePosition = moveCameraWithMouse();
			theta += cameraRelativePosition.x;
			phi = Mathf.Clamp(phi + cameraRelativePosition.y, minphi, maxphi);
		}
		return _lookAtMousePosition;
	}
}
