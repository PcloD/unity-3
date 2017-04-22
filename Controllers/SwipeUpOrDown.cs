/*
  Simple code snippet to do an action when swipping up or down
  to adapt it for left and right swipe just do the same thing in the X axis instead of doing it in the Y axis
*/

void Update() {

	#if UNITY_ANDROID
		if(Input.touchCount == 1)                                                     // screen is touched
		{
			Touch touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Began) {
				firstTouch = touch.position;
				lastTouch = touch.position;
			} else if (touch.phase == TouchPhase.Moved) {
				lastTouch = touch.position;
			} else if (touch.phase == TouchPhase.Ended) {
				lastTouch = touch.position;

				// checking if it is a drag
				if (Mathf.Abs(lastTouch.y - firstTouch.y) > dragDistance)                 // checking if it's a drag
				{
					if(lastTouch.y > firstTouch.y) {                                        // checking if it's an up swipe
						DoSomething()
					} else if (lastTouch.y < firstTouch.y) {                                // checking if it's a down swipe
					  DoSomething()
					}
				}
			}
		}
	#endif
}
