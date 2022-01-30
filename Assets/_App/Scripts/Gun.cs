using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private Transform gunpoint;

	private Pool bullets;

	private void Awake() {
		bullets = Pool.Create(bulletPrefab);
	}

	public void Shoot() {
		PoolElement bullet = bullets.GetElement();
		bullet.gameObject.transform.position = gunpoint.position;
		bullet.gameObject.transform.rotation = gunpoint.rotation;
		bullet.gameObject.SetActive(true);
	}
}
