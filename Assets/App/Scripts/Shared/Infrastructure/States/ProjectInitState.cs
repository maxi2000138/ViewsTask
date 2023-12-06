using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;
using UnityEngine;

namespace App.Scripts.Infrastructure.Installers
{
    public class ProjectInitState : IEnterState
    {
        private readonly IDataContainersStorage _dataContainersStorage;

        public ProjectInitState(IDataContainersStorage dataContainersStorage)
        {
            _dataContainersStorage = dataContainersStorage;
        }
        
        public UniTask Enter(IGameStateMachine gameStateMachine)
        {
            SetupGameFps();
            return UniTask.CompletedTask;
        }

        private void SetupGameFps()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
            
            _dataContainersStorage.LoadStaticData();
        }
    }
}