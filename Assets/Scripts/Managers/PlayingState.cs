using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class PlayingState : GameState
    {
        private int player = 0;

        public override void Handle()
        {
            var digit = Input.inputString
                .FirstOrDefault(c => char.IsDigit(c));

            if(digit != '\0')
            {
                var id = Convert.ToInt32(digit.ToString());
                if (id != player && id < context.m_Tanks.Length)
                {
                    context.DisableTankControl();
                    player = id;
                }
            }

            // As soon as the round begins playing let the players control the tanks.
            EnableTankControl(player);

            if (OneTankLeft())
            {
                PlayerPrefs.SetInt("PlayerMoney", PlayerPrefs.GetInt("PlayerMoney") + 100);

                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(),
                    PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString()) + Time.timeSinceLevelLoad);

                context.TransitionTo(gameObject.GetComponent<EndingState>());
            }
        }

        // This is used to check if there is one or fewer tanks remaining and thus the round should end.
        private bool OneTankLeft()
        {
            // Start the count of tanks left at zero.
            int numTanksLeft = 0;

            // Go through all the tanks...
            for (int i = 0; i < context.m_Tanks.Length; i++)
            {
                // ... and if they are active, increment the counter.
                if (context.m_Tanks[i].m_Instance.activeSelf)
                    numTanksLeft++;
            }

            // If there are one or fewer tanks remaining return true, otherwise return false.
            return numTanksLeft <= 1;
        }


        private void EnableTankControl(int playerID)
        {
            context.m_Tanks[playerID].EnableControl();
        }
    }
}
