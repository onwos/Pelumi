using System;
using HutongGames.PlayMaker;
using Opertoon.Panoply;

namespace HutongGames.Playmaker.Actions {
	
	[ActionCategory("Panoply")]
	[Tooltip("Goes to the previous step.")]
	public class GoToPreviousStep : FsmStateAction{
		
		public override void OnEnter() {
			if (PanoplyCore.scene != null) {
				PanoplyCore.DecrementStep ();
			}
			Finish ();
		}
		
		public override void OnExit() {}
		
		public override void Reset() {}
		
		public override string ErrorCheck() {
			return "";
		}
		
	}
}