using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
	[SerializeField] private Transform[] waypoints;
	[SerializeField] private EnemiesGroup[] enemiesGroups;
	[SerializeField] private GameObject playerPrefab;
	[SerializeField] private GameObject[] gunPrefabs;

	private GameObject playerGo;
	private CharacterAI playerAI;
	private CharacterShoot playerShoot;

	private int currentWaypoint = 0;

	private void Awake() {
		Transform spawn = waypoints[currentWaypoint];
		playerGo = Instantiate(playerPrefab, spawn.position, spawn.rotation);
		playerAI = playerGo.GetComponent<CharacterAI>();
		playerShoot = playerGo.GetComponent<CharacterShoot>();
		GameObject gun = Instantiate(gunPrefabs[Random.Range(0,2)]);
		playerShoot.SetGun(gun);
	}

	private void OnEnable() {
		LevelUI.OnPlayTap += MoveToNextPoint;
		foreach (var enemyGroup in enemiesGroups)
			enemyGroup.OnKill += EnemyGroupKilled;
	}

	private void OnDisable() {
		LevelUI.OnPlayTap -= MoveToNextPoint;
		ScreenTapHandler.OnTapRaycast -= OnScreenTapHit;
		foreach (var enemyGroup in enemiesGroups)
			enemyGroup.OnKill -= EnemyGroupKilled;
	}

	private void EnemyGroupKilled() {
		print("enemy group killed");
		ScreenTapHandler.OnTapRaycast -= OnScreenTapHit;
		MoveToNextPoint();
	}

	private void MoveToNextPoint() {
		print("move next point");
		currentWaypoint++;
		playerAI.MoveTo(waypoints[currentWaypoint], OnWaypointReached);
	}

	private void OnWaypointReached() {
		print("waypoint reached");
		if (currentWaypoint == waypoints.Length-1) {
			print("Win");
			SceneManager.LoadScene(0);
		} else {
			ScreenTapHandler.OnTapRaycast += OnScreenTapHit;
		}
	}

	private void OnScreenTapHit(RaycastHit hit) {
		playerShoot.ShootTo(hit.point);
	}
}
