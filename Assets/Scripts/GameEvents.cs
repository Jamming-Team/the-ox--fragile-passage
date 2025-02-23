using System;

namespace MoI
{
    public static class GameEvents
    {
        public static Action<int> OnSuccessInput;
        public static Action OnGameLost;
        public static Action OnGameWon;

        public static Action OnPressStart;
        public static Action OnPressSettings;
        public static Action OnPressHowToPlay;
        
        public static Action OnPressBack;

        
        public static Action OnPressPause;

        public static Action OnPressContinue;
        public static Action OnPressRestart;
        public static Action OnPressToMainMenu;


        public static Action<float> OnChangeMusicVolume;
        public static Action<float> OnChangeSFXVolume;
        
        public static Action<float> OnChangeMinTempValue;
        public static Action<float> OnChangeVictoryTimer;
    }
}