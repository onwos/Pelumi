using System;
using HutongGames.PlayMaker;
using Opertoon.Panoply;

namespace HutongGames.Playmaker.Actions {

	[ActionCategory("Panoply")]
	[Tooltip("Triggers an event when leaving a specific step.")]
	public class LeaveStep : FsmStateAction{

		[Tooltip("The step on the global timeline which, when left behind, triggers the event.")]
		public int step;
		[Tooltip("The event to be triggered when moving forward from the step.")]
		public FsmEvent forwardEvent;
		[Tooltip("The event to be triggered when moving backward from the step.")]
		public FsmEvent backwardEvent;
		
		public override void OnEnter() {
			PanoplyEventManager.OnTargetStepChanged += HandleTargetStepChanged;
		}
		
		public override void OnExit() {
			PanoplyEventManager.OnTargetStepChanged -= HandleTargetStepChanged;
		}

		public void HandleTargetStepChanged( int oldStep, int newStep ) {
		
			if ( oldStep == step ) {
				if ( newStep > oldStep ) {
					Fsm.Event( forwardEvent );
				} else if ( newStep < oldStep ) {
					Fsm.Event( backwardEvent );
				}
			}
			
		}
		
		public override void Reset() {
			step = 0;
			forwardEvent = null;
			backwardEvent = null;
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