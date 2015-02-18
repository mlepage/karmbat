using System;
using System.Collections;
using UnityEngine;
using InControl;

// This custom profile is enabled by adding it to the Custom Profiles list
// on the InControlManager component, or you can attach it yourself like so:
// InputManager.AttachDevice( new UnityInputDevice( "KeyboardAndMouseProfile" ) );
// 
public class KeyboardAndMouseProfile : UnityInputDeviceProfile
{
	public KeyboardAndMouseProfile()
	{
		Name = "Keyboard/Mouse";
		Meta = "A keyboard and mouse combination profile appropriate for FPS.";

		// This profile only works on desktops.
		SupportedPlatforms = new[]
		{
			"Windows",
			"Mac",
			"Linux"
		};

		Sensitivity = 1.0f;
		LowerDeadZone = 0.0f;
		UpperDeadZone = 1.0f;

		AnalogMappings = new[]
		{
			new InputControlMapping
			{
				Handle = "Move X",
				Target = InputControlType.LeftStickX,
				// KeyCodeAxis splits the two KeyCodes over an axis. The first is negative, the second positive.
				Source = KeyCodeAxis( KeyCode.S, KeyCode.F )
			},
			new InputControlMapping
			{
				Handle = "Move Y",
				Target = InputControlType.LeftStickY,
				// Notes that up is positive in Unity, therefore the order of KeyCodes is down, up.
				Source = KeyCodeAxis( KeyCode.D, KeyCode.E )
			},
			new InputControlMapping {
				Handle = "Look X",
				Target = InputControlType.RightStickX,
				Source = KeyCodeAxis( KeyCode.J, KeyCode.L )
			},
			new InputControlMapping {
				Handle = "Look Y",
				Target = InputControlType.RightStickY,
				Source = KeyCodeAxis( KeyCode.K, KeyCode.I )
			}
		};
	}
}
