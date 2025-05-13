//-----------------------------------------------------------------------
// <copyright file="CardboardStartup.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------
using Google.XR.Cardboard;
using UnityEngine;
using UnityEngine.XR.Management;

public class CardboardStartup : MonoBehaviour
{
    public void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;

        var xrManager = XRGeneralSettings.Instance.Manager;
        if (xrManager.activeLoader == null)
        {
            Debug.LogError("🚨 XR Loader NO está activo. Intentando inicializar...");
            xrManager.InitializeLoaderSync();
        }
        else
        {
            Debug.Log("✅ XR Loader ya estaba activo.");
        }

        if (!Api.HasDeviceParams())
        {
            Api.ScanDeviceParams();
        }
    }

    public void Update()
    {
        if (Api.IsGearButtonPressed)
        {
            Api.ScanDeviceParams();
        }

        if (Api.IsCloseButtonPressed)
        {
            Application.Quit();
        }

        if (Api.IsTriggerHeldPressed)
        {
            Api.Recenter();
        }

        if (Api.HasNewDeviceParams())
        {
            Api.ReloadDeviceParams();
        }

        Api.UpdateScreenParams();
    }
}

