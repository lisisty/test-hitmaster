using System;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
	public Action<Ragdoll> OnHit;
	private Rigidbody[] rigidbodies;
	private Animator animator;

	private void Awake() {
		animator = GetComponent<Animator>();
		rigidbodies = GetComponentsInChildren<Rigidbody>();
		foreach (var rb in rigidbodies)
			rb.gameObject.AddComponent<HitHandler>().Subscribe(Hit);
		EnableRagdoll(false);
	}

	private void Hit() {
		if (OnHit != null) OnHit(this);
		EnableRagdoll(true);
	}

	private void SetRigidbodiesKinematic(bool active) {
		foreach (var rb in rigidbodies)
			rb.isKinematic = active;
	}

	private void EnableRagdoll(bool value) {
		SetRigidbodiesKinematic(!value);
		animator.enabled = !value;
	}
}
