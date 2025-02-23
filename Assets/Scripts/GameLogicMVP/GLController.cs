using System;
using UnityEngine;

namespace MoI.GameLogicMVP
{
    public class GLController : MonoBehaviour
    {
        [SerializeField] 
        private SoundData _sparkSound;
        
        [SerializeField]
        private GameObject _sparkPrefab;
        [SerializeField]
        private Transform _sparkSpawnPoint;

        private WGDataSO.GameData _data;

        [SerializeField]
        private GLView _view;
        
        private GLModel _model;


        private bool _isActive = false;
        
        // private void Start()
        // {
        //     Init();
        // }


        public void Init(WGDataSO wgDataSO)
        {
            _data = wgDataSO.gameData;
            _model = new GLModel(_data.gameMaxTemp, _data.victoryTimer, 
                _data.gameDecreaseRate, _data.fireFadeRate, _data.gameMinTemp, _data);
            
            GameEvents.OnSuccessInput += OnSuccessInput;
        }

        private void OnSuccessInput(int obj)
        {
            _model.FuelUpFire(obj * _data.valuePerCharacter);
            
            Instantiate(_sparkPrefab, _sparkSpawnPoint.position, Quaternion.identity);
            SoundManager.Instance.CreateSoundBuilder()
                .WithRandomPitch()
                .WithPosition(transform.position)
                .Play(_sparkSound);
        }

        private void Update()
        {
            if (!_isActive)
                return;
            
            // Debug.Log(_model._glModelData.victoryTimerValue);
            _model.UpdateValues(Time.deltaTime);

            // Debug.Log(_data.GetTempFillRate(_model._glModelData.tempValue));
            
            var viewData = new GLViewData
            {
                tempTrueValue = _model._glModelData.tempValue,
                tempFill = _data.GetTempFillRate(_model._glModelData.tempValue),
                fireValue = _data.GetFireFillRate(_model._glModelData.fireValue),
                fireFill = _model._glModelData.fireValue,
                timerValue = _model._glModelData.victoryTimerValue,
                
                healthFill = _model._glModelData.health
            };
            _view.UpdateState(viewData);
        }


        
    }
}