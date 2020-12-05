using Complete;
using SOData;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public int m_NumRoundsToWin = 5;            // The number of rounds a single player has to win to win the game.
        public float m_StartDelay = 3f;             // The delay between the start of RoundStarting and RoundPlaying phases.
        public float m_EndDelay = 3f;               // The delay between the end of RoundPlaying and RoundEnding phases.
        public CameraControl m_CameraControl;       // Reference to the CameraControl script for control during different phases.
        public Text m_MessageText;                  // Reference to the overlay Text to display winning text, etc.
        public GameObject m_TankPrefab;             // Reference to the prefab the players will control.
        public TankManager[] m_Tanks;               // A collection of managers for enabling and disabling different aspects of the tanks.
        public SceneLoadingSettings sceneLoadingSettings;
        public Button finishButton;

        private GameState gameState;                // Current state of GameManager.
        private int m_RoundNumber;                  // Which round the game is currently on.
        private TankManager m_RoundWinner;          // Reference to the winner of the current round.  Used to make an announcement of who won.
        private TankManager m_GameWinner;           // Reference to the winner of the game.  Used to make an announcement of who won.

        public int RoundNumber
        {
            get => m_RoundNumber;
            set => m_RoundNumber = value;
        }

        public TankManager RoundWinner
        {
            get => m_RoundWinner;
            set => m_RoundWinner = value;
        }

        public TankManager GameWinner
        {
            get => m_GameWinner;
            set => m_GameWinner = value;
        }

        private void Start()
        {
            SpawnAllTanks();
            SetCameraTargets();
            TransitionTo(gameObject.GetComponent<StartingState>());
        }

        private void Update()
        {
            gameState.Handle();
        }

        public void TransitionTo(GameState state)
        {
            gameState = state;
            gameState.Context = this;
        }

        public void DisableTankControl()
        {
            for (int i = 0; i < m_Tanks.Length; i++)
            {
                m_Tanks[i].DisableControl();
            }
        }

        private void SpawnAllTanks()
        {
            // For all the tanks...
            for (int i = 0; i < m_Tanks.Length; i++)
            {
                // ... create them, set their player number and references needed for control.
                m_Tanks[i].m_Instance =
                    Instantiate(
                        m_TankPrefab,
                        m_Tanks[i].m_SpawnPoint.position,
                        m_Tanks[i].m_SpawnPoint.rotation
                        ) as GameObject;

                m_Tanks[i].m_PlayerNumber = i + 1;
                m_Tanks[i].Setup();
            }
        }

        private void SetCameraTargets()
        {
            // Create a collection of transforms the same size as the number of tanks.
            Transform[] targets = new Transform[m_Tanks.Length];

            // For each of these transforms...
            for (int i = 0; i < targets.Length; i++)
            {
                // ... set it to the appropriate tank transform.
                targets[i] = m_Tanks[i].m_Instance.transform;
            }

            // These are the targets the camera should follow.
            m_CameraControl.m_Targets = targets;
        }
    }
}