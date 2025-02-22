using System;
using UnityEngine;

namespace MoI.GameLogicMVP
{
    public class GLController : MonoBehaviour
    {
        [SerializeField]
        private WGDataSO _wgDataSO;
        private WGDataSO.GameData _data => _wgDataSO.gameData;

        [SerializeField]
        private GLView _view;
        
        private GLModel _model;


        private void Start()
        {
            Init();
        }


        public void Init()
        {
            _model = new GLModel(_data.gameMaxTemp, _data.victoryTimer, _data.gameDecreaseRate, _data.fireFadeRate);
            
            
        }

        private void Update()
        {
            // Debug.Log(_model._glModelData.victoryTimerValue);
            _model.UpdateValues(Time.deltaTime);

            Debug.Log(_data.GetTempFillRate(_model._glModelData.tempValue));
            
            var viewData = new GLViewData
            {
                tempTrueValue = _model._glModelData.tempValue,
                tempFill = _data.GetTempFillRate(_model._glModelData.tempValue),
                fireValue = _data.GetFireFillRate(_model._glModelData.fireValue),
                fireFill = _model._glModelData.fireValue,
                timerValue = _model._glModelData.victoryTimerValue
            };
            _view.UpdateState(viewData);
        }


    }
}