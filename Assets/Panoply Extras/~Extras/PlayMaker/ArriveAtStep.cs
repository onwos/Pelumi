using System;
using HutongGames.PlayMaker;
using Opertoon.Panoply;

namespace HutongGames.Playmaker.Actions {

	[ActionCategory("Panoply")]
	[Tooltip("Triggers an event when arriving at a specific step.")]
	public class ArriveAtStep : FsmStateAction{

		[Tooltip("The step on the global timeline at which the event is to be triggered.")]
		public int step;
		[Tooltip("Determines whether the event can be triggered whenever the step is reached, or only while traveling forward or backward along the global timeline.")]
		public PanoplyStepDirection direction;
		[Tooltip("The event to be triggered.")]
		public FsmEvent fsmevent;
		
		public override void OnEnter() {
			PanoplyEventManager.OnTargetStepChanged += HandleTargetStepChanged;
		}
		
		public override void OnExit() {
			PanoplyEventManager.OnTargetStepChanged -= HandleTargetStepChanged;
		}

		public void HandleTargetStepChanged( int oldStep, int newStep ) {
		
			if ( newStep == step ) {
			
				switch ( direction ) {
				
				case PanoplyStepDirection.BothDirections:
					Fsm.Event( fsmevent );
					break;
				
				case PanoplyStepDirection.ForwardOnly:
					if ( newStep > oldStep ) {
						Fsm.Event( fsmevent );
					}
					break;
				
				case PanoplyStepDirection.BackwardOnly:
					if ( newStep < oldStep ) {
						Fsm.Event( fsmevent );
					}
					break;
				
				}
			}
			
		}
		
		public override void Reset() {
			step = 0;
			direction = PanoplyStepDirection.BothDirections;
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