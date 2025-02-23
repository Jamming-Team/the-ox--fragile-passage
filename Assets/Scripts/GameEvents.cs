using System;

namespace MoI
{
    public static class GameEvents
    {
        public static Action<int> OnSuccessInput;

        public static Action OnPressStart;
        public static Action OnPressSettings;
        public static Action OnPressHowToPlay;
        
        public static Action OnPressBack;

        
        public static Action OnPressPause;

        public static Action OnPressContinue;
        public static Action OnPressRestart;
        public static Action OnPressToMainMenu;
    }
}