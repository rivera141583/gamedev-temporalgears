using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
	public float FollowSpeed = 2f;
	public Transform target;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y, -10f);
		transform.position = new Vector3(
			Mathf.Lerp(transform.position.x, newPos.x, FollowSpeed * Time.deltaTime),
			Mathf.Lerp(transform.position.y, newPos.y, FollowSpeed * Time.deltaTime), 
			newPos.z);
	}
}
