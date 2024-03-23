using HutongGames.PlayMaker;
using Opertoon.Panoply;

namespace HutongGames.Playmaker.Actions {
	
	[ActionCategory("Panoply")]
	[Tooltip("Enables navigation.")]
	public class EnableNavigation : FsmStateAction{
		
		public override void OnEnter() {
			if (PanoplyCore.scene != null) {
				PanoplyCore.scene.disableNavigation = false;
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