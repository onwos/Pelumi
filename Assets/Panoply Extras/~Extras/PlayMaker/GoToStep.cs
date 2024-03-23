using System;
using HutongGames.PlayMaker;
using Opertoon.Panoply;

namespace HutongGames.Playmaker.Actions {
	
	[ActionCategory("Panoply")]
	[Tooltip("Goes to a specific step.")]
	public class GoToStep : FsmStateAction{
		
		[Tooltip("The destination step.")]
		public int step;
		[Tooltip("Whether the transition to the new step should be instantaneous.")]
		public bool instantaneously;
		
		public override void OnEnter() {
			if (PanoplyCore.scene != null) {
				PanoplyCore.SetTargetStep (step);
				if (instantaneously) {
					PanoplyCore.SetInterpolatedStep (step);
				}
			}
			Finish ();
		}
		
		public override void OnExit() {
		}
		
		public override void Reset() {
			step = 0;
			instantaneously = false;
		}
		
		public override string ErrorCheck() {
			return "";
		}
		
	}
}