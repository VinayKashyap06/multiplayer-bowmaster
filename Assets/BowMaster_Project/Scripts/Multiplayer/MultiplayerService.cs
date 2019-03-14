﻿using System.Collections;
using System.Collections.Generic;
using Zenject;
using UnityEngine;
using InputSystem;
using PlayerSystem;
using GameSystem;

namespace MultiplayerSystem
{
    public class MultiplayerService : IMultiplayerService
    {
        IPlayerService playerService;
        IGameService gameService;
        PlayerName playerServerName;
        LauncherManager launch;
        bool connected = false;
        CommunicationManager communicationManager;
        public void SetConnected()
        {
            connected = true;
        }
        public void ChangeToGamePlayState()
        {
            gameService.ChangeToGamePlayState();
        }
        public MultiplayerService(IPlayerService playerService,IGameService gameService)
        {
            this.gameService = gameService;
            playerServerName = new PlayerName();
            //launch = GameObject.FindObjectOfType<Launcher>();
            this.playerService = playerService;
            //this.inputService = inputService;
        }

        public void Connect(string name)
        {
            playerServerName.SetPlayerName(name);
        }
        public bool CheckConnection()
        {
            return connected;
        }

        public void SendNewInput(InputData inputData)
        {
            if (communicationManager != null)
                communicationManager.SendInputData(inputData);
        }

        public void SetCommunicationManager(CommunicationManager communicationManager)
        {
            
                this.communicationManager = communicationManager;
        }
        public void SendInputDataToPlayer(InputData inputData)
        {
            playerService.SetPlayerData(inputData, false);
        }
        public void SetLocalPlayerID(string localID)
        {
            playerService.SetLocalPlayerID(localID);
        }

        public void SpawnPlayer(PlayerSpawnData playerSpawnData)
        {
            playerService.PlayerConnected(playerSpawnData);
        }

        public void ChangeToGameDisconnectedState()
        {
            throw new System.NotImplementedException();
        }

        public void ChangeToLobbyState()
        {
            throw new System.NotImplementedException();
        }
    }
}