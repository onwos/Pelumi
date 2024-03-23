using System;
using HutongGames.PlayMaker;
using Opertoon.Panoply;

namespace HutongGames.Playmaker.Actions {

	[ActionCategory("Panoply")]
	[Tooltip("Triggers an event when leaving the current step.")]
	public class LeaveCurrentStep : FsmStateAction{

		[Tooltip("The event to be triggered when moving forward from this step.")]
		public FsmEvent forwardEvent;
		[Tooltip("The event to be triggered when moving backward from this step.")]
		public FsmEvent backwardEvent;
		//[Tooltip("Whether moving backward should load the previous state of the panel.")]
		//public boolean goBackwardInHistory;
		
		public override void OnEnter() {
			PanoplyEventManager.OnTargetStepChanged += HandleTargetStepChanged;
		}
		
		public override void OnExit() {
			PanoplyEventManager.OnTargetStepChanged -= HandleTargetStepChanged;
		}
		
		public void HandleTargetStepChanged( int oldStep, int newStep ) {

			if ( newStep > oldStep ) {
				Fsm.Event( forwardEvent );
			} else if ( newStep < oldStep ) {
				//if ( goBackwardInHistory ) {
					// pop the previous state off the stack
				//}
				Fsm.Event( backwardEvent );
			}
			
		}
		
		public override void Reset() {
			forwardEvent = null;
			backwardEvent = null;
			//goBackwardInHistory = true;
		}

		public override string ErrorCheck() {
			if ( FsmEvent.IsNullOrEmpty( forwardEvent ) && FsmEvent.IsNullOrEmpty( backwardEvent ) ) {
				return "Action sends no events!";
			} else {
				return "";
			}
		}

	}
}