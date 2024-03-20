using ObserverPattern;

namespace Aviator
{
    public static class Events_Aviator
    {
        public static ObserveEvent<int, int> OnPressBetButton = new();

        public static ObserveEvent<BaseGameState> OnUpdateGameState = new();
    }
}