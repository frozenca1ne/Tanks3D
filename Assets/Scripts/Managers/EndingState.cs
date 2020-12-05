using System.Collections;
using Complete;
using UnityEngine;

namespace Managers
{
    public class EndingState : GameState
    {
        private Coroutine coroutine = null;

        public override void Handle()
        {
            coroutine = coroutine ?? StartCoroutine(EndingCoroutine());
        }

        private IEnumerator EndingCoroutine()
        {
            // Stop tanks from moving.
            context.DisableTankControl();

            // Clear the winner from the previous round.
            context.RoundWinner = null;

            // See if there is a winner now the round is over.
            context.RoundWinner = GetRoundWinner();

            // If there is a winner, increment their score.
            if (context.RoundWinner != null)
                context.RoundWinner.m_Wins++;

            // Now the winner's score has been incremented, see if someone has one the game.
            context.GameWinner = GetGameWinner();

            // Get a message based on the scores and whether or not there is a game winner and display it.
            string message = EndMessage();
            context.m_MessageText.text = message;

            // Wait for the specified length of time until yielding control back to the game loop.

            // This code is not run until 'RoundEnding' has finished.  At which point, check if a game winner has been found.
            if (context.GameWinner != null)
            {
                context.finishButton.gameObject.SetActive(true);
                while (true) yield return null;
            }
            else
            {
                yield return new WaitForSeconds(context.m_EndDelay);
                context.TransitionTo(gameObject.GetComponent<StartingState>());
                coroutine = null;
            }
        }

        // This function is to find out if there is a winner of the round.
        // This function is called with the assumption that 1 or fewer tanks are currently active.
        private TankManager GetRoundWinner()
        {
            // Go through all the tanks...
            for (int i = 0; i < context.m_Tanks.Length; i++)
            {
                // ... and if one of them is active, it is the winner so return it.
                if (context.m_Tanks[i].m_Instance.activeSelf)
                    return context.m_Tanks[i];
            }

            // If none of the tanks are active it is a draw so return null.
            return null;
        }

        // This function is to find out if there is a winner of the game.
        private TankManager GetGameWinner()
        {
            // Go through all the tanks...
            for (int i = 0; i < context.m_Tanks.Length; i++)
            {
                // ... and if one of them has enough rounds to win the game, return it.
                if (context.m_Tanks[i].m_Wins == context.m_NumRoundsToWin)
                    return context.m_Tanks[i];
            }

            // If no tanks have enough rounds to win, return null.
            return null;
        }

        // Returns a string message to display at the end of each round.
        private string EndMessage()
        {
            // By default when a round ends there are no winners so the default end message is a draw.
            string message = "DRAW!";

            // If there is a winner then change the message to reflect that.
            if (context.RoundWinner != null)
                message = context.RoundWinner.m_ColoredPlayerText + " WINS THE ROUND!";

            // Add some line breaks after the initial message.
            message += "\n\n\n\n";

            // Go through all the tanks and add each of their scores to the message.
            for (int i = 0; i < context.m_Tanks.Length; i++)
            {
                message += context.m_Tanks[i].m_ColoredPlayerText + ": " + context.m_Tanks[i].m_Wins + " WINS\n";
            }

            // If there is a game winner, change the entire message to reflect that.
            if (context.GameWinner != null)
                message = context.GameWinner.m_ColoredPlayerText + " WINS THE GAME!";

            return message;
        }
    }
}
