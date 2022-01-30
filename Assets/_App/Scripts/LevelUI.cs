using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
	public static Action OnPlayTap;
	public static Action OnRestartTap;
	public static Action OnMuteTap;

	[SerializeField] private Button playBtn;
	[SerializeField] private Button restartBtn;
	[SerializeField] private Button muteBtn;

	private void Awake() {
		playBtn.onClick.AddListener(PlayTap);
		// restartBtn.onClick.AddListener(PlayTap);
		// muteBtn.onClick.AddListener(PlayTap);
	}

	private void Start() {
		playBtn.gameObject.SetActive(true);
		restartBtn.gameObject.SetActive(false);
		muteBtn.gameObject.SetActive(false);
	}

	private void PlayTap() {
		if (OnPlayTap != null) OnPlayTap();
		playBtn.gameObject.SetActive(false);
		restartBtn.gameObject.SetActive(true);
		muteBtn.gameObject.SetActive(true);
	}

	// private void RestartTap() {
	// 	if (OnRestartTap != null) OnRestartTap();
	// }

	// private void MuteTap() {
	// 	if (OnMuteTap != null) OnMuteTap();
	// }
}
