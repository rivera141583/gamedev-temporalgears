using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_AnimationHandler : MonoBehaviour
{
	public bool isWalking = false;
	public bool isAttacking = false;
	public bool playerDirection = false;

	Animator animator;
	// Start is called before the first frame update
	void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		animator.SetBool("IsWalking", isWalking);
		animator.SetBool("IsAttacking", isAttacking);


		if (playerDirection) // left
		{
			transform.localScale = Vector3.one;
		}
		else // right
		{
			transform.localScale = new Vector3(-1,1,1);
		}
	}
}
