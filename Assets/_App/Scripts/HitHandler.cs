using System;
using UnityEngine;

public class HitHandler : MonoBehaviour
{
	private Action OnHit;
	private Rigidbody rb;

	private void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	public void Subscribe(Action OnHit) {
		this.OnHit = OnHit;
	}

	private void OnTriggerEnter(Collider collider) {
		if (OnHit != null) OnHit();
		rb.AddForce(collider.transform.forward * 2000f);
	}
}
