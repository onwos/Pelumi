using System;
using HutongGames.PlayMaker;
using Opertoon.Panoply;

namespace HutongGames.Playmaker.Actions {
	
	[ActionCategory("Panoply")]
	[Tooltip("Goes to the last step.")]
	public class GoToLastStep : FsmStateAction{
		
		[Tooltip("Whether the transition to the new step should be instantaneous.")]
		public bool instantaneously;
		
		public override void OnEnter() {
			if (PanoplyCore.scene != null) {
				PanoplyCore.GoToLastStep ();
				if (instantaneously) {
					PanoplyCore.SetInterpolatedStep (PanoplyCore.targetStep);
				}
			}
			Finish ();
		}
		
		public override void OnExit() {
		}
		
		public override void Reset() {
			instantaneously = false;
		}
		
		public override string ErrorCheck() {
			return "";
		}
		
		
	}
}