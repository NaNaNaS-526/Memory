using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
	[SerializeField]private GameObject shirt;
	[SerializeField]private SceneController controller;
	private int _id;
	public int id
	{
		get{return _id;}
	}
	public void SetCard(int id, Sprite image)
	{
 		_id = id;
 		GetComponent<SpriteRenderer>().sprite = image;
	}
	public void OnMouseDown()
	{
		if(shirt.activeSelf && controller.canReveal)
		{
			shirt.SetActive(false);
			controller.CardRevealed(this); 
		}
	}
	public void Unreveal()
	{
		shirt.SetActive(true);
	}
}
