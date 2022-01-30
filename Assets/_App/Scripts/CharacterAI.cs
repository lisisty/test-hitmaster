using System;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class CharacterAI : MonoBehaviour
{
	private Action OnArrival;

	private ThirdPersonCharacter character;
	private NavMeshAgent agent;
	private Animator animator;

	private Transform waypoint;
	private bool arrival;

	private void Awake() {
		character = GetComponent<ThirdPersonCharacter>();
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}

	private void Start() {
		agent.updateRotation = false;
	}

	private void Update() {
		if (waypoint == null) return;

		if (Vector3.Distance(gameObject.transform.position, waypoint.position) > 0.2f) {
			character.Move(agent.desiredVelocity, false, false);
		} else {
			character.Move(Vector3.zero, false, false);
			gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, waypoint.rotation, Time.deltaTime * 2f);
			if (OnArrival != null && !arrival) {
				arrival = true;
				OnArrival();
			}
		}
	}

	public void MoveTo(Transform point, Action OnArrival = null) {
		agent.SetDestination(point.position);
		this.OnArrival = OnArrival;
		this.waypoint = point;
		arrival = false;
	}
}
