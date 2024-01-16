using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Damage_Detect : MonoBehaviour
{
	public Drone drone;
	public WeaponHandler weapon;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("bum: " + collision.name);
		if (collision.gameObject.tag == "Player_Melee")
		{
			Debug.Log("ei");
			drone.health -= weapon.swordDamage;
		}
		else if (collision.gameObject.tag == "PlayerBullet")
		{
			Debug.Log("ei");
			drone.health -= weapon.gunDamage;
		}
	}
}
