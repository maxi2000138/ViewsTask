using System;
using BitBenderGames;
using UnityEngine;

[ExecuteInEditMode]
public class OrientationCameraHandle : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private MobileTouchCamera TouchCamera;
    [SerializeField] private float _startSize;
    
    private float _startWidth;

    void OnEnable()
    {
        _startWidth = GetStartWidth();
        OnOrientationChanged(OrientationListener.previousOrientation);
        OrientationListener.OnOrientationChanged += OnOrientationChanged;
    }

    void OnDisable()
    {
        OrientationListener.OnOrientationChanged -= OnOrientationChanged;
    }

    void OnOrientationChanged(ScreenOrientation orientation)
    {
        if (mainCamera != null && TouchCamera != null)
        {
            mainCamera.orthographicSize *= _startWidth/GetCurrentWidth();
            TouchCamera.CamZoomMin = mainCamera.orthographicSize;
            TouchCamera.CamZoomMax = mainCamera.orthographicSize;
        }
    }

    private float GetStartWidth() => GetWidth(_startSize);
    private float GetCurrentWidth() => GetWidth(mainCamera.orthographicSize);
    private float GetWidth(float size) => size * Screen.width / Screen.height;
}