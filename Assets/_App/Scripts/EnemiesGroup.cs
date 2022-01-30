using System;
using UnityEngine;

public class EnemiesGroup : MonoBehaviour
{
	public Action OnKill;
	private Ragdoll[] enemies;
	private int killedCount;

	void Awake() {
		enemies = gameObject.GetComponentsInChildren<Ragdoll>();
	}

	private void OnEnable() {
		foreach (var enemy in enemies) {
			enemy.OnHit += OnEnemyKilled;
		}
	}

	private void OnDisable() {
		foreach (var enemy in enemies) {
			enemy.OnHit -= OnEnemyKilled;
		}
	}

	private void OnEnemyKilled(Ragdoll enemy) {
		enemy.OnHit -= OnEnemyKilled;
		killedCount++;
		if (enemies.Length == killedCount) {
			if (OnKill != null) OnKill();
		}
	}
}
