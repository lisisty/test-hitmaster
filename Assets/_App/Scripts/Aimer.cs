using System;
using UnityEngine;

public class Aimer : MonoBehaviour
{
	[SerializeField] private Transform aimPoint;
	[SerializeField] private float aimSpeed = 20f;
	
	private Action OnAimed;
	private Vector3 target;
	private bool aiming;

	public void ResetAim() {
		AimTo(gameObject.transform.forward*10f);
	}

	public void AimTo(Vector3 target, Action OnAimed = null) {
		aiming = true;
		this.target = target;
		this.OnAimed = OnAimed;
	}

	private void Update() {
		if (!aiming) return;
		aimPoint.position = Vector3.Lerp(aimPoint.position, target, Time.deltaTime * aimSpeed);
		if (Vector3.Distance(aimPoint.position, target) < 0.01f) {
			if (OnAimed != null) OnAimed();
			aiming = false;
		}
	}
}
