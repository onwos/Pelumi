using UnityEngine;
using Opertoon.Panoply;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory ("Panoply")]
	[Tooltip ("Enables navigation for the specified Panoply panel.")]
	public class EnablePanelNavigation : FsmStateAction
	{

		[Tooltip ("Panel for which navigation will be enabled.")]
		public Panel panel;

		// Code that runs every frame.
		public override void OnUpdate ()
		{
			if (panel != null) {
				panel.interceptInteraction = false;
			}
			Finish ();
		}


	}

}
