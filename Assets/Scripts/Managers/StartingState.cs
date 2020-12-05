using System.Collections;
using Complete;
using UnityEngine;

namespace Managers
{
    public class StartingState : GameState
    {
        private Coroutine coroutine = null;

        public override void Handle()
        {
            coroutine = coroutine ?? StartCoroutine(StartingCoroutine());
        }

        private IEnumerator StartingCoroutine()
        {
            // As soon as the round starts reset the tanks and make sure they can't move.
            ResetAllTanks();
            context.DisableTankControl();

            // Snap the camera's zoom and position to something appropriate for the reset tanks.
            context.m_CameraControl.SetStartPositionAndSize();

            // Increment the round number and display text showing the players what round it is.
            context.RoundNumber++;
            context.m_MessageText.text = "ROUND " + context.RoundNumber;

            // Wait for the specified length of time until yielding control back to the game loop.
            yield return new WaitForSeconds(context.m_StartDelay);

            // Clear the text from the screen.
            context.m_MessageText.text = string.Empty;

            context.TransitionTo(gameObject.GetComponent<PlayingState>());

            coroutine = null;
        }

        // This function is used to turn all the tanks back on and reset their positions and properties.
        private void ResetAllTanks()
        {
            foreach (var t in context.m_Tanks)
            {
                t.Reset();
            }
        }
    }
}
