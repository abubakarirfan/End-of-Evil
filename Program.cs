using CombatGame;
using SplashKitSDK;

public class Program
{
        
    /// <summary>
    /// This is used to check the state of the program
    /// </summary>
    
    public enum StateName
    {
        MAINMENU,
        TWOPLAYERGAMEPLAY,
        ONEPLAYERGAMEPLAY,
        SELECTPLAYER,
        INSTRUCTIONS,
        GAMEOVER
    }

    /// <summary>
    /// This is used to execute the program
    /// </summary>

    public static void Main()
    {
        StateName currentState = StateName.MAINMENU;

        new Window("End of Evil", 800, 600);

        string winner = "Default";
        string selectedPlayerName = "Default";

        MainMenu mainMenu = new MainMenu(); 
        GamePlay twoPlayerGamePlay = new TwoPlayerGamePlay();
        GamePlay onePlayerGamePlayer = new OnePlayerGamePlay(); ;
        SelectPlayer selectPlayer = new SelectPlayer(); ;
        Instructions instructions = new Instructions(); ;
        GameOver gameOver = new GameOver();
        
        do
        {
            if (currentState == StateName.MAINMENU)
            {
                mainMenu.CheckState = 0;
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
                instructions.CheckState = 0;
                instructions.Execute();

                if (instructions.CheckState == 1)
                {
                    currentState = StateName.MAINMENU;
                }
            }

            if (currentState == StateName.SELECTPLAYER)
            {
                selectPlayer.CheckState = 0;
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
                twoPlayerGamePlay.CheckState = 0;
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
                onePlayerGamePlayer.CheckState = 0;
                onePlayerGamePlayer.AssignSelectedPlayer(selectedPlayerName);
                onePlayerGamePlayer.AssignPlayersCoordinates();
                onePlayerGamePlayer.Execute();

                if (onePlayerGamePlayer.CheckState == 1)
                {
                    currentState = StateName.GAMEOVER;
                    winner = onePlayerGamePlayer.Winner;
                }
            }

            if (currentState == StateName.GAMEOVER)
            {
                gameOver.CheckState = 0;
                gameOver.Winner = winner;
                gameOver.Execute();

                if (gameOver.CheckState == 1)
                {
                    currentState = StateName.MAINMENU;
                }
            }

        } while (!SplashKit.WindowCloseRequested("End of Evil"));
    }
}
