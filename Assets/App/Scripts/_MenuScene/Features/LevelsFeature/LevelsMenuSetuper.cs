using Dreamteck.Splines;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace _MenuLogic
{
     public class LevelsMenuSetuper : MonoBehaviour
     {
          [SerializeField] private SplineComputer _splineComputer;
          [SerializeField] private LevelButtonBase _lvlButton;
          [SerializeField] private Transform _buttonsParent;

          [SerializeField] private Vector2Int _numbersRange = new (10,90); 
          [SerializeField] private Vector2Int _percentLineSpawnRange; 

#if UNITY_EDITOR
          [Button]
          public void Setup()
          {
               _splineComputer = GetComponent<SplineComputer>();
               _splineComputer.CalculateLength();

               int count = _numbersRange.y - _numbersRange.x + 1;
               float percentRange = (_percentLineSpawnRange.y - _percentLineSpawnRange.x) / 100f;
               float startDistance = _splineComputer.CalculateLength() * _percentLineSpawnRange.x / 100f;
               float allDistance = _splineComputer.CalculateLength() * percentRange;
               float step = allDistance / (count - 1);
               float curDistance = startDistance;
               double percent = _splineComputer.Travel(0f, startDistance);
               int index = 0; 
               while (index < count)
               {
                    Vector3 position = _splineComputer.EvaluatePosition(percent);
                    LevelButtonBase spanwedButton = PrefabUtility.InstantiatePrefab(_lvlButton, _buttonsParent) as LevelButtonBase;
                    spanwedButton.transform.position = position;
                    spanwedButton.Initialize(_numbersRange.x + index++);
                    spanwedButton.transform.localPosition = new Vector3(spanwedButton.transform.localPosition.x,
                         spanwedButton.transform.localPosition.y, 0f);
                    spanwedButton.SetLVLName();
                    curDistance += step;
                    percent = _splineComputer.Travel(0f, curDistance);
               }
          }

          [Button]
          public void Destroy()
          {
               int childCount = _buttonsParent.childCount;
               for (int i = 0; i < childCount; i++) 
                    DestroyImmediate(_buttonsParent.GetChild(0).gameObject);
          }
#endif
     }
}
