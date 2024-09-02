using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int health = 100;
	public float speed = 5f;

	void Start()
	{

	}

	void Update()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		transform.Translate(movement * speed * Time.deltaTime, Space.World);
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		Debug.Log("Player health: " + health);
		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Debug.Log("Player died!");
	}
}

