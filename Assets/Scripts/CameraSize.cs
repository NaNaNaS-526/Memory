using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
	private const float TargetSizeX = 1920f;
	private const float TargetSizeY = 1080f;
	private const float HalfSize = 200f;
	private Camera mainCamera;
	private void Awake()
	{
		mainCamera = gameObject.GetComponent<Camera>();
		CameraResize();
	}
	private void CameraResize()
	{
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float targetRatio = TargetSizeX / TargetSizeY;
		if(screenRatio >= targetRatio)
		{
			Resize();
		}
		else
		{
			float differentSize = targetRatio / screenRatio;
			Resize(differentSize);
		}
	}
	private void Resize(float differentSize = 1f)
	{
		mainCamera.orthographicSize = TargetSizeY / HalfSize * differentSize;
	}
}
