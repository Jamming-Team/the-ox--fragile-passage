using System;
using UnityEngine;

namespace MoI.GameLogicMVP
{
    public class GLModel
    {
        public Action OnVictory;
        public Action OnDefeat;


        public readonly GLModelData _glModelData = new GLModelData();

        private float _fireFadeRate;
        private float _tempFadeRate;

        private float _minTemp;
        private WGDataSO.GameData _wgData;
        private float _currentHealthDepletionRate =>
            Mathf.Lerp(0f, _wgData.maxHealthDepletionRate,
                _wgData.GetTempDamageRate(_glModelData.tempValue) - _glModelData.fireValue);


        public GLModel(float tempValue, float victoryTimerValue, float tempFadeRate, float fireFadeRate, float minTemp, WGDataSO.GameData wgData)
        {
            _glModelData.fireValue = 0f;
            _glModelData.tempValue = tempValue;
            _glModelData.victoryTimerValue = victoryTimerValue;
            _glModelData.health = 1f;

            _fireFadeRate = fireFadeRate;
            _tempFadeRate = tempFadeRate;
            _minTemp = minTemp;
            _wgData = wgData;
        }


        public void UpdateValues(float delta)
        {
            _glModelData.fireValue = Mathf.Clamp(_glModelData.fireValue - _fireFadeRate * delta, 0, 1f);
            _glModelData.tempValue = Mathf.Clamp(_glModelData.tempValue - _tempFadeRate * delta, _minTemp, 20f);
            _glModelData.victoryTimerValue -= delta;

            Debug.Log(_currentHealthDepletionRate);
            Debug.Log(_wgData.GetTempDamageRate(_glModelData.tempValue));
            
            _glModelData.health -= delta * _currentHealthDepletionRate;

            
            
            if (_glModelData.victoryTimerValue <= 0f)
            {
                OnVictory?.Invoke();
                return;
            }

            // if (_glModelData.fireValue <= 0f)
            //     OnDefeat?.Invoke();
            
            if (_glModelData.health <= 0f)
                OnDefeat?.Invoke();
            
        }

        public void FuelUpFire(float value)
        {
            
            _glModelData.fireValue = Mathf.Clamp(_glModelData.fireValue + value, 0f, 1f);
            
        }
        
        
        
    }
    
    public class GLModelData
    {
        public float fireValue;
        public float tempValue;
        public float victoryTimerValue;

        public float health;
    }
}