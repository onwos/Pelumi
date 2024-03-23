using System;
using HutongGames.PlayMaker;
using Opertoon.Panoply;
using UnityEngine;

namespace HutongGames.Playmaker.Actions
{

	[ActionCategory ("Panoply")]
	[HutongGames.PlayMaker.Tooltip ("Sets the speed of step transitions.")]
	public class SetGestureRate : FsmStateAction
	{

		[HutongGames.PlayMaker.Tooltip ("The desired gesture rate.")]
		public float gestureRate = 5;

		private PanoplyController controller;

		public override void OnEnter ()
		{
			var foundPanoplyControllers = UnityEngine.Object.FindObjectsOfType<PanoplyController> ();
			if (foundPanoplyControllers.Length > 0) {
				controller = foundPanoplyControllers [0];
			}
			if (controller != null) {
				controller.gestureRate = gestureRate;
			}
			Finish ();
		}

		public override void OnExit ()
		{
		}

		public override string ErrorCheck ()
		{
			return "";
		}

	}
}