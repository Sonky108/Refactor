using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject _image;
	public Sprite[] sprites;

	public static GameManager Instance;

	public int currentSprite = 0;

	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			currentSprite++;

			if (currentSprite >= 4)
				currentSprite = 0;

			_image.GetComponent<Image>().sprite = sprites[currentSprite];

			if (_image.GetComponent<Image>().sprite.name == "mouth_lol")
			{
				GetComponent<AudioSource>().Play();
			}

		}
	}
}