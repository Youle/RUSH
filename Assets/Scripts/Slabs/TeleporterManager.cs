using UnityEngine;
using System.Collections;

public class TeleporterManager : MonoBehaviour {
	public float _id;
	public string[] types = new [] { "sender", "receiver" };
	public int typeKey = 0;
	private string _type;
	// Use this for initialization
	void Start () {
		_type = types[typeKey];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string getType()
	{
		return _type;
	}

	public Vector3 getReceiverPosition(Vector3 initialPosition)
	{
		GameObject[] teleporters = GameObject.FindGameObjectsWithTag("Teleporter");
		foreach(GameObject teleporter in teleporters)
		{
			TeleporterManager teleporterManager = teleporter.GetComponent<TeleporterManager>();
			if(teleporterManager._id == _id && teleporterManager.getType() == "receiver")
			{
				gameObject.particleSystem.Play();
				teleporterManager.particleSystem.Play();
				return new Vector3(teleporter.transform.position.x, teleporter.transform.position.y + 0.5f, teleporter.transform.position.z);
			}
		}
		return initialPosition;
	}
}
