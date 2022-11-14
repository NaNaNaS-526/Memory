using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	private int _score;
	[SerializeField]private TextMeshProUGUI scoreLabel;
	[SerializeField]private Card originalCard;
	[SerializeField]private Sprite[] images;
	public const int gridRows = 2;
 	public const int gridCols = 4;
 	public const float offsetX = 5f;
 	public const float offsetY = 5f;
 	private Card _firstRevealed;
	private Card _secondRevealed;
	void Update()
	{
		if(_score == images.Length)
		{
			SceneManager.LoadScene("RestartScene");
		}
	}
	public bool canReveal
	{
 		get {return _secondRevealed == null;}
	}
	public void CardRevealed(Card card)
	{
		if (_firstRevealed == null)
		{
 			_firstRevealed = card;
 		}
 		else
 		{
			_secondRevealed = card;
 			StartCoroutine(CheckMatch());
		}
	}
	private IEnumerator CheckMatch()
	{
 		if (_firstRevealed.id == _secondRevealed.id)
 		{
			_score++;
			scoreLabel.text = ($"Score: {_score}");
		}
		else
		{
			yield return new WaitForSeconds(.5f);
			_firstRevealed.Unreveal();
			_secondRevealed.Unreveal();
		}
		_firstRevealed = null;
		_secondRevealed=null;
	}
	void Start()
	{
		Vector3 startPos = originalCard.transform.position;
		int[] numbers = {0, 0, 1, 1, 2, 2, 3, 3};
		numbers = ShuffleArray(numbers);
		for (int i = 0; i < gridCols; i++)
		{
			for (int j = 0; j < gridRows; j++)
			{
				Card card;
				if (i == 0 && j == 0)
				{
					card = originalCard;
				}
				else
				{
					card = Instantiate(originalCard) as Card;
				}
				int index = j * gridCols + i;
				int id = numbers[index];
				card.SetCard(id, images[id]);
				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3(posX, posY, startPos.z);
			}
		}
	}
	private int[] ShuffleArray(int[] numbers)
	{
		int[] newArray = numbers.Clone() as int[];
		for(int i = 0;i < newArray.Length;i++)
		{
			int tmp = newArray[i];
			int r = Random.Range(i, newArray.Length);
			newArray[i] = newArray[r];
			newArray[r] = tmp;
		}
		return newArray;
	}
}
