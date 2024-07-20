using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
	Game2 game2;

	void Start()
	{
		game2 = FindObjectOfType<Game2>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag != "PlayerModel") return;
		game2.Finish();
	}
}
