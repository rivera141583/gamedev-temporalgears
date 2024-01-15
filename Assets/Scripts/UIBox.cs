using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnGUI()
	{
		GUI.skin.box.fontSize = 90;
		GUI.skin.box.alignment = TextAnchor.MiddleCenter;
		GUI.skin.box.wordWrap = true;

		GUI.Box(new Rect(0f, 0f, Screen.width, Screen.height/5), "A");
	}
}
