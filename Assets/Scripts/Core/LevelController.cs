using UnityEngine;
using UnityUtils;

namespace MoI
{
    public class LevelController : Singleton<LevelController>
    {
        [SerializeField]
        private SettingsController _settingsController;
        public SettingsController settingsController => _settingsController;
        [SerializeField]
        private StateMachine _stateMachine;
        

        private void Start()
        {
            _settingsController.Init();
            _stateMachine.Init(this);
        }
    }
}