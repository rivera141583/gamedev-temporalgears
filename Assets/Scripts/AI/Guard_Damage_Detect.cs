using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_Damage_Detect : MonoBehaviour
{
	// Start is called before the first frame update
	public Guard guard;
	public WeaponHandler weapon;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player_Melee")
		{
			guard.health -= weapon.swordDamage;
		}
		else if (collision.gameObject.tag == "PlayerBullet")
		{
			guard.health -= weapon.gunDamage;
		}
	}
}
