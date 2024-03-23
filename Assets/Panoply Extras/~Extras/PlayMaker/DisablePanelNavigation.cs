using UnityEngine;
using Opertoon.Panoply;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory ("Panoply")]
	[Tooltip ("Disables navigation for the specified Panoply panel.")]
	public class DisablePanelNavigation : FsmStateAction
	{

		[Tooltip ("Panel for which navigation will be disabled.")]
		public Panel panel;

		// Code that runs every frame.
		public override void OnUpdate ()
		{
			if (panel != null) {
				panel.interceptInteraction = true;
			}
			Finish ();
		}


	}

}
