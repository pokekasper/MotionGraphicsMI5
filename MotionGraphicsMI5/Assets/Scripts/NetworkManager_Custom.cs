using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.NetworkSystem;

public class NetworkManager_Custom : NetworkManager {

        private string ipAddress;
        private int port = 7777;
        public Text textConnectionInfo;
        public Text ipAddressTextField;
        private Scene currentScene;
        public GameObject[] panelsForUI;
        private MatchInfo hostInfo;
        public Text matchRoomNameText;
        public Transform contentRoomList;
        public GameObject roomButtonPrefab;
        public Text playerNameText;
        private string playerName;
        public Text mapSelectedText;
        private string mapSelected = "Map 1";
        private int characterSelected = 0;
        public Text characterSelectedText;
        public GameObject[] characterPrefabs;
        private short playerControllerId = 0;



        #region Unity Methods
        private void OnEnable()
        {
            RegisterCharacterPrefabs();
            SceneManager.sceneLoaded += OnMySceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnMySceneLoaded;
        }

        public override void OnClientDisconnect(NetworkConnection conn)
        {
            base.OnClientDisconnect(conn);
            if (textConnectionInfo.text != null)
            {
                textConnectionInfo.text = "Disconnected or timed out.";
                ActivatePanel("PanelMainMenu");
            }
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            //Debug.Log(playerControllerId);
        }

        public override void OnClientSceneChanged(NetworkConnection conn)
        {
            IntegerMessage msg = new IntegerMessage(characterSelected);
			//Debug.Log(characterSelected);
			//Debug.Log(characterPrefabs.Length);
            ClientScene.AddPlayer(conn, playerControllerId, msg);
        }

        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
        {
            int id = 0;

            if (extraMessageReader != null)
            {
                var i = extraMessageReader.ReadMessage<IntegerMessage>();
                id = i.value;
            }
			//Tor links
			if(id == 0)
			{			
				Vector3 chosenSpawnPoint = new Vector3(-34, -20, 2);
				Quaternion chosenSpawnPointR = new Quaternion(0,0,0,0);
				//Transform chosenSpawnPoint = NetworkManager.singleton.startPositions[Random.Range(0, NetworkManager.singleton.startPositions.Count)];
				GameObject player = Instantiate(characterPrefabs[id], chosenSpawnPoint, chosenSpawnPointR) as GameObject;
			
				NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
			}
			//Tor hinten
			else if(id == 1)
			{			
				Vector3 chosenSpawnPoint = new Vector3(-5,-21,-28);
				Quaternion chosenSpawnPointR = new Quaternion();
				//Transform chosenSpawnPoint = NetworkManager.singleton.startPositions[Random.Range(0, NetworkManager.singleton.startPositions.Count)];
				GameObject player = Instantiate(characterPrefabs[id], chosenSpawnPoint, chosenSpawnPointR) as GameObject;
			
				NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
			}
			//Tor vorne
			else if(id == 2)
			{			
				Vector3 chosenSpawnPoint = new Vector3(-4,-21,30);
				Quaternion chosenSpawnPointR = new Quaternion();
				//Transform chosenSpawnPoint = NetworkManager.singleton.startPositions[Random.Range(0, NetworkManager.singleton.startPositions.Count)];
				GameObject player = Instantiate(characterPrefabs[id], chosenSpawnPoint, chosenSpawnPointR) as GameObject;
			
				NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
			}
			//Tor rechts
			else if(id == 3)
			{
				Vector3 chosenSpawnPoint = new Vector3(25,-21,-1);
				Quaternion chosenSpawnPointR = new Quaternion();
				//Transform chosenSpawnPoint = NetworkManager.singleton.startPositions[Random.Range(0, NetworkManager.singleton.startPositions.Count)];
				GameObject player = Instantiate(characterPrefabs[id], chosenSpawnPoint, chosenSpawnPointR) as GameObject;
			
				NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
			}
            
        }

        #endregion

        #region My Methods

        void RegisterCharacterPrefabs()
        {
			//ClientScene.RegisterPrefab(characterPrefabs);

            foreach (GameObject character in characterPrefabs)
            {
                ClientScene.RegisterPrefab(character);
            }
        }

        public void OnClickSelectCharacter(int charNum)
        {
            characterSelected = charNum;
			//playerControllerId = charNum;
			characterSelectedText.text = "Character " + charNum + " Selected";
        }

        public void OnClickCapturePlayerName()
        {
            if (playerNameText.text == string.Empty)
            {
                playerName = "Player";
                PlayerPrefs.SetString("PlayerName", playerName);
            }

            else
            {
                playerName = playerNameText.text;
                PlayerPrefs.SetString("PlayerName", playerName);
            }
        }

        void OnMySceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SetInitialReferences();
        }

        void SetInitialReferences()
        {
            currentScene = SceneManager.GetActiveScene();

            if (currentScene.name == "Menu")
            {
                ActivatePanel("PanelMainMenu");
            }
            else
            {
                ActivatePanel("PanelInGame");
                OnClickClearConnectionTextInfo();
            }
        }


        public void ActivatePanel(string panelName)
        {
            foreach (GameObject panelGO in panelsForUI)
            {
                if (panelGO.name.Equals(panelName))
                {
                    panelGO.SetActive(true);
                }
                else
                {
                    panelGO.SetActive(false);
                }
            }
        }

        void GetIPAddress()
        {
            ipAddress = ipAddressTextField.text;
        }

        void SetPort()
        {
            NetworkManager.singleton.networkPort = port;
        }

        void SetIPAddress()
        {
            NetworkManager.singleton.networkAddress = ipAddress;
        }

        public void OnClickClearConnectionTextInfo()
        {
            textConnectionInfo.text = string.Empty;
        }

        public void OnClickStartLANHost()
        {
            SetPort();
            NetworkManager.singleton.StartHost();
			
        }

        public void OnClickStartServerOnly()
        {
            SetPort();
            NetworkManager.singleton.StartServer();
        }

        public void OnClickJoinLANGame()
        {
            SetPort();
            GetIPAddress();
            SetIPAddress();
            NetworkManager.singleton.StartClient();
        }

        public void OnClickDisconnectFromNetwork()
        {
            NetworkManager.singleton.StopHost();
            NetworkManager.singleton.StopServer();
            NetworkManager.singleton.StopClient();
        }

        public void OnClickExitGame()
        {
            Application.Quit();
        }


        #endregion

    }