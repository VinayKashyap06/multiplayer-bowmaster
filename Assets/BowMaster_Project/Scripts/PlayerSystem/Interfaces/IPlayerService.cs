﻿using System.Collections;
using System.Collections.Generic;
using Zenject;
using UnityEngine;
using InputSystem;

namespace PlayerSystem
{
    public interface IPlayerService
    {
        void SpawnPlayer();
        void SetPlayerData(InputData inputData);
        int GetLocalPlayerID();
    }
}