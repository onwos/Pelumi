using HutongGames.PlayMaker;
using Opertoon.Panoply;

namespace HutongGames.Playmaker.Actions {
	
	[ActionCategory("Panoply")]
	[Tooltip("Disables all navigation.")]
	public class DisableNavigation : FsmStateAction{
		
		public override void OnEnter() {
			if (PanoplyCore.scene != null) {
				PanoplyCore.scene.disableNavigation = true;
			}
			Finish ();
		}
		
		public override void OnExit() {
		}
		
		public override void Reset() {
		}
		
		public override string ErrorCheck() {
			return "";
		}
		
	}
}