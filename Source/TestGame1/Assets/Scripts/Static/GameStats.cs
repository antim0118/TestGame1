using UnityEngine;

public static class GameStats
{
	public static int Score
	{
		get => PlayerPrefs.GetInt("Score", 0);
		set
		{
			PlayerPrefs.SetInt("Score", value);
			PlayerPrefs.Save();
		}
	}

	public static float Time
	{
		get => PlayerPrefs.GetFloat("Time", 0);
		set
		{
			PlayerPrefs.SetFloat("Time", value);
			PlayerPrefs.Save();
		}
	}
}
