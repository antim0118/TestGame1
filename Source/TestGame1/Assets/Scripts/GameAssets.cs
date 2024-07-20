using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GameAssets : MonoBehaviour
{
	public static Sprite SpriteClickButton;
	public static GameObject PrefabPlayerModel, PrefabFinishModel;

	[SerializeField] AssetReference clickButton;
	static Queue<AsyncOperationHandle> assetsHandlesGame1 = new Queue<AsyncOperationHandle>();

	[SerializeField] AssetReference playerModel, finishModel;
	static Queue<AsyncOperationHandle> assetsHandlesGame2 = new Queue<AsyncOperationHandle>();

	public GameObject LoadingPanel;

	public async Task<T> LoadAssetAsync<T>(AssetReference addressable, Queue<AsyncOperationHandle> queue) where T : Object
	{
		AsyncOperationHandle<T> handle = addressable.LoadAssetAsync<T>();
		await handle.Task;
		if (handle.Status == AsyncOperationStatus.Succeeded)
		{
			T t = handle.Result;
			queue.Enqueue(handle);
			return t;
		}
		else
			return null;
	}

	public async void LoadAssetsGame1()
	{
		LoadingPanel.SetActive(true);
		if (SpriteClickButton == null)
			SpriteClickButton = await LoadAssetAsync<Sprite>(clickButton, assetsHandlesGame1);
		LoadingPanel.SetActive(false);
	}

	public async void LoadAssetsGame2()
	{
		LoadingPanel.SetActive(true);
		if (PrefabPlayerModel == null)
			PrefabPlayerModel = await LoadAssetAsync<GameObject>(playerModel, assetsHandlesGame2);
		if (PrefabFinishModel == null)
			PrefabFinishModel = await LoadAssetAsync<GameObject>(finishModel, assetsHandlesGame2);
		LoadingPanel.SetActive(false);
	}

	public void UnloadAssetsGame1()
	{
		SpriteClickButton = null;
		AsyncOperationHandle handle;
		while (assetsHandlesGame1.Count > 0)
		{
			handle = assetsHandlesGame1.Dequeue();
			Addressables.Release(handle);
		}
	}

	public void UnloadAssetsGame2()
	{
		PrefabPlayerModel = null;
		PrefabFinishModel = null;
		AsyncOperationHandle handle;
		while (assetsHandlesGame2.Count > 0)
		{
			handle = assetsHandlesGame2.Dequeue();
			Addressables.Release(handle);
		}
	}
}
