using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
	public float explosionRadius = 5f;
	public float explosionForce = 700f;
	public int damage = 20;
	public GameObject explosionEffect;
	public bool canExplode = false; 
	private Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	void OnCollisionEnter(Collision collision)
	{
		if (canExplode && collision.gameObject.CompareTag("Player"))
		{
			animator.SetTrigger("Open");
			Explode();
			Player player = collision.gameObject.GetComponent<Player>();
			if (player != null)
			{
				player.TakeDamage(damage);
			}
		}
	}

	void Explode()
	{
		if (explosionEffect != null)
		{
			Instantiate(explosionEffect, transform.position, transform.rotation);
		}

		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach (Collider nearbyObject in colliders)
		{
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
			if (rb != null)
			{
				rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
			}
		}

		

		Destroy(gameObject);
	}
}
