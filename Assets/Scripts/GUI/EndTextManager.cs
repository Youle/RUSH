using UnityEngine;
using System.Collections;

public class EndTextManager : MonoBehaviour {
	public void Win()
	{
		guiText.text = "BRAVO";
	}

	public void Loose()
	{
		guiText.text = "PERDU";
	}
}
