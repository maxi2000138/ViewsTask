using System;
using UnityEngine;
using UnityEngine.SceneManagement;


[ExecuteInEditMode]
public class OrientationListener : MonoBehaviour
{
    public delegate void OrientationChanged(ScreenOrientation orientation);
    public static event OrientationChanged OnOrientationChanged;

    private float previousAspect;
    private string _previousScene;
    public static ScreenOrientation previousOrientation;

    void OnStateChanged()
    {
        previousOrientation = ScreenOrientation.Unknown;
    }
    
    void Update()
    {
        if (SceneManager.GetActiveScene().name != _previousScene)
        {
            OnStateChanged();
            _previousScene = SceneManager.GetActiveScene().name;
        }
        
        ChangeOrientation();
    }

    private void ChangeOrientation()
    {
        var v = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        v = new Vector3(Screen.width, Screen.height, 0);
        var aspect = Screen.height / (float)Screen.width;

        if ((v.x > v.y) && (ScreenOrientation.LandscapeLeft != previousOrientation) || aspect != previousAspect)
            SetOrientation(ScreenOrientation.LandscapeLeft);

        else if ((v.x > v.y) && (ScreenOrientation.LandscapeLeft != previousOrientation) || aspect != previousAspect)
            SetOrientation(ScreenOrientation.LandscapeLeft);

        else if ((v.x < v.y) && (ScreenOrientation.Portrait != previousOrientation) || aspect != previousAspect)
            SetOrientation(ScreenOrientation.Portrait);

        else if ((v.x < v.y) && (ScreenOrientation.Portrait != previousOrientation) || aspect != previousAspect)
            SetOrientation(ScreenOrientation.Portrait);
    }

    private void SetOrientation(ScreenOrientation orientation)
    {
        previousAspect = Screen.height / (float)Screen.width;
        previousOrientation = orientation;
        if (OnOrientationChanged != null)
            OnOrientationChanged(orientation);
    }
}