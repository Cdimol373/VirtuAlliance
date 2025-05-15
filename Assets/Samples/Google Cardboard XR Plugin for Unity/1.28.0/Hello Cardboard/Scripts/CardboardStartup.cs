<<<<<<< Updated upstream
﻿//-----------------------------------------------------------------------
=======
//-----------------------------------------------------------------------
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
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

=======

using Google.XR.Cardboard;
using UnityEngine;

/// <summary>
/// Initializes Cardboard XR Plugin.
/// </summary>
public class CardboardStartup : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        // Configures the app to not shut down the screen and sets the brightness to maximum.
        // Brightness control is expected to work only in iOS, see:
        // https://docs.unity3d.com/ScriptReference/Screen-brightness.html.
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;

        // Checks if the device parameters are stored and scans them if not.
>>>>>>> Stashed changes
        if (!Api.HasDeviceParams())
        {
            Api.ScanDeviceParams();
        }
    }

<<<<<<< Updated upstream
=======
    /// <summary>
    /// Update is called once per frame.
    /// </summary>
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
