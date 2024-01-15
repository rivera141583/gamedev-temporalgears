using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
	double health { get;set; }

	void Damage();
}
