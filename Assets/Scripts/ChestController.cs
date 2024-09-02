using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
	public Cofre[] cofres;

	void Start()
	{
		int randomIndex = Random.Range(0, cofres.Length);

		for (int i = 0; i < cofres.Length; i++)
		{
			if (i == randomIndex)
			{
				cofres[i].canExplode = true; 
			}
			else
			{
				cofres[i].canExplode = false; 
			}
		}
	}
}