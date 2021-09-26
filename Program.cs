using CombatGame;
using SplashKitSDK;

public class Program
{
    public enum StateName
    {
        MAINMENU,
        TWOPLAYERGAMEPLAY,
        ONEPLAYERGAMEPLAY,
        SELECTPLAYER,
        INSTRUCTIONS,
        GAMEOVER
    }

    public static void Main()
    {
        StateName currentState = StateName.MAINMENU;

        new Window("End of Evil", 800, 600);

        MainMenu mainMenu = null;
        TwoPlayerGamePlay twoPlayerGamePlay = null;
        OnePlayerGamePlayer onePlayerGamePlayer = null;
        SelectPlayer selectPlayer = null;
        string selectedPlayerName = null;
        Instructions instructions = null;
        GameOver gameOver = null;
        string winner = null;

        do
        {
            if (currentState == StateName.MAINMENU)
            {
                mainMenu = new MainMenu();
                mainMenu.Execute();


                if (mainMenu.CheckState == 1)
                {
                    currentState = StateName.SELECTPLAYER;
                }

                if (mainMenu.CheckState == 2)
                {
                    currentState = StateName.SELECTPLAYER;
                }

                if (mainMenu.CheckState == 3)
                {
                    currentState = StateName.INSTRUCTIONS;
                }
            }

            if (currentState == StateName.INSTRUCTIONS)
            {
                instructions = new Instructions();
                instructions.Execute();

                if (instructions.CheckState == 1)
                {
                    currentState = StateName.MAINMENU;
                }
            }

            if (currentState == StateName.SELECTPLAYER)
            {
                selectPlayer = new SelectPlayer();
                selectPlayer.Execute();

                if (selectPlayer.CheckState == 7)
                {
                    currentState = StateName.MAINMENU;
                }
                else
                {
                    if (selectPlayer.CheckState == 1)
                    {
                        selectedPlayerName = selectPlayer.SelectedPlayer;
                    }
                    if (selectPlayer.CheckState == 2)
                    {
                        selectedPlayerName = selectPlayer.SelectedPlayer;
                    }
                    if (selectPlayer.CheckState == 3)
                    {
                        selectedPlayerName = selectPlayer.SelectedPlayer;
                    }
                    if (selectPlayer.CheckState == 4)
                    {
                        selectedPlayerName = selectPlayer.SelectedPlayer;
                    }
                    if (selectPlayer.CheckState == 5)
                    {
                        selectedPlayerName = selectPlayer.SelectedPlayer;
                    }
                    if (selectPlayer.CheckState == 6)
                    {
                        selectedPlayerName = selectPlayer.SelectedPlayer;
                    }
                    if (mainMenu.CheckState == 1)
                    {
                        currentState = StateName.ONEPLAYERGAMEPLAY;
                    }
                    else
                    {
                        currentState = StateName.TWOPLAYERGAMEPLAY;
                    }
                }
            }

            if (currentState == StateName.TWOPLAYERGAMEPLAY)
            {
                twoPlayerGamePlay = new TwoPlayerGamePlay();
                twoPlayerGamePlay.AssignSelectedPlayer(selectedPlayerName);
                twoPlayerGamePlay.AssignPlayersCoordinates();
                twoPlayerGamePlay.Execute();

                if (twoPlayerGamePlay.CheckState == 1)
                {
                    currentState = StateName.GAMEOVER;
                    winner = twoPlayerGamePlay.Winner;
                }
            }

            if (currentState == StateName.ONEPLAYERGAMEPLAY)
            {
                onePlayerGamePlayer = new OnePlayerGamePlayer();
                onePlayerGamePlayer.AssignSelectedPlayer(selectedPlayerName);
                onePlayerGamePlayer.AssignCoordinatesForStart();
                onePlayerGamePlayer.Execute();

                if (onePlayerGamePlayer.CheckState == 1)
                {
                    currentState = StateName.GAMEOVER;
                    winner = onePlayerGamePlayer.Winner;
                }
            }


            if (currentState == StateName.GAMEOVER)
            {
                gameOver = new GameOver(winner);
                gameOver.Execute();

                if (gameOver.CheckState == 1)
                {
                    currentState = StateName.MAINMENU;
                }
            }

        } while (!SplashKit.WindowCloseRequested("End of Evil"));
    }
}
