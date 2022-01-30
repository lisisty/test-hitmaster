using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
	[SerializeField] private Aimer aimer;
	[SerializeField] private Transform gunHolder;
	private Gun gun;

	public void SetGun(GameObject gunGo) {
		Gun gun = gunGo.GetComponent<Gun>();
		this.gun = gun;
		gunGo.transform.parent = gunHolder;
		gunGo.transform.localPosition = Vector3.zero;
		gunGo.transform.localRotation = Quaternion.identity;
	}

	public void ShootTo(Vector3 target) {
		aimer.AimTo(target, OnAimed);
	}

	private void OnAimed() {
		gun.Shoot();
	}
}
