using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
	public Animator animation;
	public BoxCollider2D collider;
	public GameObject door;
	public Rigidbody2D body;
	bool opened = false;
	float targetPos;
    // Start is called before the first frame update
    void Start()
    {
		targetPos = door.transform.position.y + 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (opened)
		{
			if (door.transform.position.y < targetPos)
			{
				body.velocity = new Vector2(0, 4);
			}
			else if (door.transform.position.y >= targetPos)
			{
				door.SetActive(false);
			}
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "PlayerBullet")
		{
			collider.enabled = false;
			opened = true;
			animation.SetBool("opened", true);
		}
	}
}
