using UnityEngine;
using UnityEngine.UI;

public class Game1 : MonoBehaviour
{
	public Text text;

	void Start()
	{
		UpdateText();
	}

	void UpdateText()
	{
		text.text = GameStats.Score.ToString();
	}

	public void Click()
	{
		GameStats.Score++;
		UpdateText();
	}
}
