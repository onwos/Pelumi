using System;
using HutongGames.PlayMaker;
using Opertoon.Panoply;

namespace HutongGames.Playmaker.Actions {
	
	[ActionCategory("Panoply")]
	[Tooltip("Triggers an event when exiting a specific range of steps.")]
	public class ExitStepRange : FsmStateAction{
		
		[Tooltip("Defines the low end of the range of steps on the global timeline.")]
		public int minimumStep;
		[Tooltip("Defines the high end of the range of steps on the global timeline.")]
		public int maximumStep;
		[Tooltip("The event to be triggered.")]
		public FsmEvent fsmevent;
		
		public override void OnEnter() {
			PanoplyEventManager.OnTargetStepChanged += HandleTargetStepChanged;
		}
		
		public override void OnExit() {
			PanoplyEventManager.OnTargetStepChanged -= HandleTargetStepChanged;
		}
		
		public void HandleTargetStepChanged( int oldStep, int newStep ) {
			
			if ((( oldStep >= minimumStep ) && ( oldStep <= maximumStep )) && (( newStep < minimumStep ) || ( newStep > maximumStep ))) {
				Fsm.Event( fsmevent );
			}
			
		}
		
		public override void Reset() {
			minimumStep = 0;
			maximumStep = 0;
			fsmevent = null;
		}
		
		public override string ErrorCheck() {
			if ( FsmEvent.IsNullOrEmpty( fsmevent ) ) {
				return "Action sends no events!";
			} else {
				return "";
			}
		}
		
	}
}