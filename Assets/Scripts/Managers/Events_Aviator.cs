using Mother;

namespace Aviator
{
    public static class Events_Aviator
    {
        public static MotherEvent<int, int> OnPressBetButton = new();

        public static MotherEvent<BaseGameState> OnUpdateGameState = new();
    }
}