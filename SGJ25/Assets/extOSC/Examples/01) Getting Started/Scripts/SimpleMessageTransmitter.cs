/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;

namespace extOSC.Examples
{
	public class SimpleMessageTransmitter : MonoBehaviour
	{
        #region Public Vars

        public string StartAddress = "/music/start";
        public string EndAddress = "/music/stop";

        [Header("OSC Settings")]
		public OSCTransmitter Transmitter;

        #endregion

        #region Unity Methods

        protected virtual void Start()
        {
            var message = new OSCMessage(StartAddress);
            message.AddValue(OSCValue.String("Hello, world!"));

            Transmitter.Connect();
            Transmitter.Send(message);
        }

        private void OnApplicationQuit()
        {
            var message = new OSCMessage(EndAddress);
            message.AddValue(OSCValue.String("Hello, world!"));

            Transmitter.Send(message);
        }

        #endregion
    }
}