using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	public string[] levels = new [] { "Arrows", "Fall And Teleport", "Split And Conveyors", "Walls and Stop" };

	void Start () {
	}
	
	void Update () {
	
	}

	void OnGUI()
	{
		int i = 0;
		float marginUp = (Screen.height - (levels.Length * 50)) / 2;
		foreach(string level in levels)
		{
			i++;
			if(GUI.Button(new Rect(Screen.width/2 - 100, marginUp + (50 * (i - 1)), 200, 30), level))
			{
				Application.LoadLevel(i);
			}
			
		}
	}
}
