using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Game2 : MonoBehaviour
{
	public GameObject PlayermodelDummy;
	public GameObject FinishDummy;
	public Text timeText;
	public GameObject finishPanel;

	SceneController sceneController;
	Stopwatch stopwatch;

	bool isFinished = false;

	void Start()
	{
		sceneController = GetComponent<SceneController>();
		stopwatch = Stopwatch.StartNew();
		finishPanel.SetActive(false);
	}

	void Update()
	{
		timeText.text = stopwatch.Elapsed.ToString("mm':'ss");
	}

	public void Finish()
	{
		if (isFinished) return;
		isFinished = true;

		stopwatch.Stop();

		if (GameStats.Time == 0f || GameStats.Time > stopwatch.Elapsed.TotalSeconds)
			GameStats.Time = (float)stopwatch.Elapsed.TotalSeconds;

		UpdateTimeText();
	}

	public void Restart()
	{
		sceneController.LoadGame2();
	}

	public void ResetTime()
	{
		GameStats.Time = 0;
		UpdateTimeText();
	}

	void UpdateTimeText()
	{
		finishPanel.SetActive(true);
		TimeSpan bestTime = TimeSpan.FromSeconds(GameStats.Time);
		finishPanel.GetComponentInChildren<Text>().text = $"Time: {stopwatch.Elapsed:mm':'ss}\n" +
			$"Best Time: {bestTime:mm':'ss}";
	}
}
