using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour
{
	[SerializeField] LightTest_Environment environment;
	[SerializeField] Sprite gaugeDown; 
	[SerializeField] Sprite gaugeUp;
	SpriteRenderer renderer;

	private void Start()
	{
		renderer = GetComponent<SpriteRenderer>();
	}

	void Update()
    {
        if (environment.SteamPowerActivated)
		{
			renderer.sprite = gaugeUp;
		}
		else
		{
			renderer.sprite = gaugeDown;
		}
    }
}
