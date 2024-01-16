using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog1 : MonoBehaviour
{
	public float speed = 30f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
