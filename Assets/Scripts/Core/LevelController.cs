using System.Collections.Generic;
using MoI.GameLogicMVP;
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
        
        [SerializeField]
        private GLController _glController;
        [SerializeField]
        private WGController _wgController;


        public int successesCount;
        public int failsCount;

        public int charactersCount;


        private List<string> _dictList;
        
        private void Start()
        {
            Application.targetFrameRate = 60;
            DictionaryLoader.LoadDictionary(out _dictList);

            _settingsController.Init();
            _stateMachine.Init(this);
            IntroGame();
        }

        public void StartGame()
        {
            successesCount = 0;
            failsCount = 0;
            charactersCount = 0;
            _wgController.Activate(_dictList);
            _glController.Activate(_settingsController._data);
        }

        public void StopGame()
        {
            _wgController.Deactivate();
            _glController.Deactivate();
        }

        public void IntroGame()
        {
            _glController.SetIntro();
        }
    }
}