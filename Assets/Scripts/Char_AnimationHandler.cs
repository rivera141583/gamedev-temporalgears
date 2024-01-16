using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_AnimationHandler : MonoBehaviour
{
	public bool isRunning = false;
	public bool isJumping = false;
	public bool isFalling = false;
	public bool isGrounded = false;
	public bool isShooting = false;
	public bool isSwinging = false;
	public int shootDirection = 0;
	public bool direction = false;
	Animator animation;

	// Start is called before the first frame update
	void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
	{
		animation.SetBool("IsRunning", isRunning);
		animation.SetBool("IsJumping", isJumping);
		animation.SetBool("IsFalling", isFalling);
		animation.SetBool("IsGrounded", isGrounded);
		animation.SetBool("IsSwinging", isSwinging);
		animation.SetBool("IsShooting", isShooting);
		animation.SetInteger("AimDirection", shootDirection);
		if (direction)
		{
			this.transform.localScale = new Vector3(-1,1,1);
		}
		else
		{
			this.transform.localScale = new Vector3(1, 1, 1);
		}
	}
}
