
namespace Datentypen
{
    enum ApplicationState
    {
        Stopped,
        StartingUp,
        Paused,
        Running,
        ShuttingDown,
    }


    class BitteIgnorieren
    {
        void MeineMethode()
        {
            ApplicationState AppState = ApplicationState.Stopped;

            if (AppState == ApplicationState.Stopped)
            {
                AppState = ApplicationState.StartingUp;
            }


            int AppStateAsInt = 0;

            if (AppStateAsInt == 0)
            {
                AppStateAsInt = 2;
            }




        }
    }

}
