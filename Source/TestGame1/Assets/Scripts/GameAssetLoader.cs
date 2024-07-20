using UnityEngine;
using UnityEngine.UI;

public class GameAssetLoader : MonoBehaviour
{
	public Component component;
	Game1 game1;
	Game2 game2;

	void Start()
	{
		game1 = FindObjectOfType<Game1>();
		game2 = FindObjectOfType<Game2>();

		// GAME 1 //
		if (game1 != null)
		{
			if (component.GetType() == typeof(Image))
			{
				Image image = (Image)component;
				image.sprite = GameAssets.SpriteClickButton;
			}
		}

		// GAME 2 //
		if (game2 != null)
		{
			if (tag == "PlayerModel" && component.GetType() == typeof(PlayerController))
			{
				PlayerController player = (PlayerController)component;

				if (GameAssets.PrefabPlayerModel != null)
				{
					GameObject model = Instantiate(GameAssets.PrefabPlayerModel);
					model.transform.parent = transform;
					model.transform.localPosition = new Vector3(0, 7.8f, 0);
					player.animator = model.GetComponent<Animator>();
				}
				game2.PlayermodelDummy.SetActive(GameAssets.PrefabPlayerModel == null);
			}
			else if (tag == "Finish")
			{
				if (GameAssets.PrefabFinishModel != null)
				{
					GameObject finish = Instantiate(GameAssets.PrefabFinishModel);
					finish.transform.parent = transform;
					finish.transform.localPosition = Vector3.zero;
				}
				game2.FinishDummy.SetActive(GameAssets.PrefabFinishModel == null);
			}
		}

	}
}