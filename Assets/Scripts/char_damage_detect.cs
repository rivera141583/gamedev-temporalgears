using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class char_damage_detect : MonoBehaviour
{
	public ResourceHandler resource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy_Melee")
		{
			if (collision.gameObject.name == "Enemy_Halberd")
			{
				resource.health -= 10;
			}
		}
		if (collision.gameObject.tag == "Enemy_Bullet")
		{
			resource.health -= 10;
			
		}
	}
}
