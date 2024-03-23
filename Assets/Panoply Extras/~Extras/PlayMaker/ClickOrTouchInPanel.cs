using UnityEngine;
using Opertoon.Panoply;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("Panoply")]
	[Tooltip("Fires an event when a click or touch is detected within the specified Panoply panel.")]
	public class ClickOrTouchInPanel : FsmStateAction
	{

        [Tooltip("Panel to monitor for mouse clicks.")]
        public Panel panel;

        [Tooltip("Event to send when a click or touch is detected within the panel.")]
        public FsmEvent clickOrTouchEvent;

        // Code that runs every frame.
        public override void OnUpdate()
		{
			if (Input.GetMouseButtonUp( 0 ))
            {
                if (panel.frameRect.Contains(Input.mousePosition))
                {
                    Fsm.Event(clickOrTouchEvent);
                }
            } else {
				for (int i = 0; i < Input.touches.Length; i++) {
					if (Input.touches [i].phase == TouchPhase.Began) {
						if (panel.frameRect.Contains (Input.touches [i].position)) {
							Fsm.Event (clickOrTouchEvent);
							break;
						}
					}
				}
			}
		}


	}

}
