using System;
using UnityEngine;

public class ScreenTapHandler : MonoBehaviour
{
	public static Action<RaycastHit> OnTapRaycast;

	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (OnTapRaycast != null) OnTapRaycast(hit);
			}
		}
	}
}
