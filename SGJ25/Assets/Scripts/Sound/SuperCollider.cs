/* Copyright (c) 2025 Simon Cornaz */

using UnityEngine;
using extOSC;
using System;
using System.IO;
using System.Diagnostics;

namespace SuperCollider
{
    public class SuperCollider : MonoBehaviour
    {
        [Header("OSC Settings")]
        public OSCTransmitter Transmitter;

        public bool DevMode = false;
        public bool isFirstScene = false;
        public string SoundDirectory;
        public string FileName;

        private Process process = null;

        #region Unity Methods

        protected virtual void Start()
        {
            if (DevMode || !isFirstScene)
            {
                OnReady();
                return;
            }
            foreach (var p in Process.GetProcessesByName("sclang"))
            {
                p.Kill();
            }
            try
            {
                process = new Process();
                process.StartInfo.WorkingDirectory = Path.Combine(Application.dataPath, SoundDirectory, "sclang");
                process.StartInfo.FileName = Path.Combine(Application.dataPath, SoundDirectory, "sclang", "sclang.exe"); 
                process.StartInfo.Arguments = Path.Combine(Application.dataPath, SoundDirectory, FileName);
                process.EnableRaisingEvents = false;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardError = true;
                process.OutputDataReceived += new DataReceivedEventHandler(DataReceived);
                process.ErrorDataReceived += new DataReceivedEventHandler(ErrorReceived);
                process.Start();
                process.BeginOutputReadLine();
                //var messageStream = process.StandardInput;

                UnityEngine.Debug.Log("Successfully launched app");
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError("Unable to launch app: " + e.Message);
            }
        }
        public void Init()
        {
            Transmitter.Connect();
        }

        public void SendMsg(string Msg, params object[] Args)
        {
            var message = new OSCMessage(Msg);

            foreach (var A in Args)
            {
                if (A.GetType() == typeof(bool))
                {
                    message.AddValue(OSCValue.Bool((bool)A));
                }
                else if (A.GetType() == typeof(string))
                {
                    message.AddValue(OSCValue.String((string)A));
                }
                else if (A.GetType() == typeof(int))
                {
                    message.AddValue(OSCValue.Int((int)A));
                }
                else if (A.GetType() == typeof(float))
                {
                    message.AddValue(OSCValue.Float((float)A));
                }
            }
            Transmitter.Send(message);
        }

        public void OnApplicationQuit()
        {
            if (DevMode)
            {
                return;
            }
            foreach (Process p in System.Diagnostics.Process.GetProcessesByName("scsynth"))
            {
                p.Kill();
            }
            process.Kill();
            process.WaitForExit();
        }

        private void DataReceived(object sender, DataReceivedEventArgs eventArgs)
        {
            UnityEngine.Debug.Log(eventArgs.Data);
            if (eventArgs.Data.Contains("server ready"))
            {
                OnReady();
            }
        }

        private void ErrorReceived(object sender, DataReceivedEventArgs eventArgs)
        {
            UnityEngine.Debug.LogError(eventArgs.Data);
        }

        private void OnReady()
        {
            UnityEngine.Debug.Log("Super Collider is Ready !");
            Transmitter.Connect();
        }

        #endregion
    }
}