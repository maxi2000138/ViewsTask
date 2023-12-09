using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;
using UnityEngine;

namespace App.Scripts.Infrastructure.Installers
{
    public class ProjectInitState : IEnterState
    {
        public UniTask Enter(IGameStateMachine gameStateMachine)
        {
            SetupGameFps();
            gameStateMachine.Enter<ProjectLoadDataState>();
            return UniTask.CompletedTask;
        }

        private void SetupGameFps()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
        }
    }
}