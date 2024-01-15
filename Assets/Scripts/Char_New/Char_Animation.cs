using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Animation : MonoBehaviour
{
	public bool isRunning = false;
	public bool isJumping = false;
	public bool isFalling = false;
	public bool isGrounded = false;
	public bool isAttacking = false;
	public int weapon = 0; // 0 = broad; 1 = short; 2 = gun;
	public int gunAngle = 0; // 0 = forward; 1 = angled; 2 = up;
	public bool direction = false; // true = left; false = right;
	Animator animation;

	float y = 0;

	// Start is called before the first frame update
	void Start()
    {
        animation = GetComponent<Animator>();
		y = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
	{
		animation.SetBool("Attacking", isAttacking);
		animation.SetBool("Running", isRunning);
		animation.SetBool("Jumping", isJumping);
		animation.SetBool("Falling", isFalling);
		animation.SetBool("Grounded", isGrounded);

		animation.SetInteger("Gun_Angle", gunAngle);

		switch (weapon)
		{
			case 0:
				animation.SetBool("Weapon_Broad", true);
				animation.SetBool("Weapon_Short", false);
				animation.SetBool("Weapon_Gun", false);
				break;
			case 1:
				animation.SetBool("Weapon_Broad", false);
				animation.SetBool("Weapon_Short", true);
				animation.SetBool("Weapon_Gun", false);
				break;
			case 2:
				animation.SetBool("Weapon_Broad", false);
				animation.SetBool("Weapon_Short", false);
				animation.SetBool("Weapon_Gun", true);
				break;
		}

		if (direction)
		{
			this.transform.localScale = new Vector3(1,y,1);
		}
		else
		{
			this.transform.localScale = new Vector3(-1, y, 1);
		}
	}
}
