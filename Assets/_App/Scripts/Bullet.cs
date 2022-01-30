using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
	[SerializeField] private float speed = 3f;

	private void OnEnable() {
		Invoke("Dispose", 3f);
	}

	private void OnDisable() {
		CancelInvoke();
	}

	private void Dispose() {
		gameObject.SetActive(false);
	}

    private void Update() {
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}

	private void OnTriggerEnter(Collider _) {
		gameObject.SetActive(false);
	}
}
