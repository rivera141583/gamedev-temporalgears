using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
	public Fade fade;
	public void OnButtonClick()
	{
		fade.StartGame();
	}
}
