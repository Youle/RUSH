using UnityEngine;
using System.Collections;

public class AlphaGUI : MonoBehaviour {
	void OnGUI()
	{
		if(GUI.Button(new Rect(5, 5, 200, 30), "Back to menu"))
		{
			Application.LoadLevel(0);
		}
			
	}
}
