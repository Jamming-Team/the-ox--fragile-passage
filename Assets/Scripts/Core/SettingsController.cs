using System;
using UnityEngine;

namespace MoI
{
    public class SettingsController : MonoBehaviour
    {
        const string MUSIC_VOLUME_NAME = "MusicVolume";
        const string SFX_VOLUME_NAME = "SFXVolume";
        
        [SerializeField]
        private WGDataSO _wgDataSO;
        public WGDataSO.GameData _data => _wgDataSO.gameData;

        public void Init()
        {
            SetMusicVolume(_data.musicVolume);
            SetSFXVolume(_data.SFXVolume);
        }

        private void OnEnable()
        {
            GameEvents.OnChangeMusicVolume += SetMusicVolume;
            GameEvents.OnChangeSFXVolume += SetSFXVolume;
            
            GameEvents.OnChangeMinTempValue += OnChangeMinTempValue;
            GameEvents.OnChangeVictoryTimer += OnChangeVictoryTimer;
        }
        
        private void OnDisable()
        {
            GameEvents.OnChangeMusicVolume -= SetMusicVolume;
            GameEvents.OnChangeSFXVolume -= SetSFXVolume;
            
            GameEvents.OnChangeMinTempValue -= OnChangeMinTempValue;
            GameEvents.OnChangeVictoryTimer -= OnChangeVictoryTimer;
        }

        
        private void SetMusicVolume(float volume)
        {
            SoundManager.Instance.mixer.SetFloat(MUSIC_VOLUME_NAME, Mathf.Log10(volume) * 20f);
            _data.musicVolume = volume;
        }
        
        private void SetSFXVolume(float volume)
        {
            SoundManager.Instance.mixer.SetFloat(SFX_VOLUME_NAME, Mathf.Log10(volume) * 20f);
            _data.SFXVolume = volume;
        }
        
        private void OnChangeMinTempValue(float obj)
        {
            _data.gameMinTemp = obj;
        }
        
        private void OnChangeVictoryTimer(float obj)
        {
            _data.victoryTimer = obj;
        }
    }
}