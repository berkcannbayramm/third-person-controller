# Third Person Movement System in Unity

This project demonstrates a third-person character movement system using Unity's new Input System, State Machine, and Cinemachine. It includes a demo scene for testing and visualization.

## Features

- **Third-Person Character Movement:** Smooth and responsive character control.
- **State Machine Implementation:** Organized code structure for character states (Idle, Walking, Running, Jumping).
- **Cinemachine Integration:** Dynamic camera control for a polished player experience.
- **New Input System:** Modern and flexible input handling for various devices.

## Getting Started

### Prerequisites

- **Unity Version:** Ensure you have Unity 2020.1 or later installed.
- **Packages:**
  - [Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@latest)
  - [Cinemachine](https://docs.unity3d.com/Packages/com.unity.cinemachine@latest)

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/berkcannbayramm/third-person-controller.git
2. **Open the project:**
   Open the project folder in Unity Hub.
3. **Install required packages:**
	Go to `Window > Package Manager`, search for and install the Input System and Cinemachine packages.
### Usage
### Input System Setup
1. **Enable the new Input System:**
	Go to `Edit > Project Settings > Player`, and under `Other Settings`, set `Active Input Handling` to `Input System Package (New)`.
2. **Configure Input Actions:**
	- Locate the `InputActions` asset in the project.
	- Define actions for movement, jumping, and other interactions as needed.
### State Machine Implementation
The character controller uses a state machine to manage different states (Idle, Walking, Jumping).
1. **State Machine Overview:**

	- **IdleState:** Default state when the character is not moving.
	- **WalkState:** Handles character movement.
	- **JumpState:** Handles jumping actions.
2. **Adding New States:**

-   Create a new script inheriting from `ICharacterState`.
-   Override the necessary methods (`EnterState`, `UpdateState`, `ExitState`).
### Cinemachine Setup

1.  **Add Cinemachine to the scene:**
    
    -   Go to `GameObject > Cinemachine > Create FreeLook Camera`.
    -   Assign the character as the Follow and LookAt target.
2.  **Configure the Camera:**
    
    -   Adjust the FreeLook camera settings to suit your game's requirements.
### Demo Scene

A demo scene is included for quick testing and visualization of the third-person movement system.

1.  **Open the demo scene:**
    -   Navigate to `Assets > Scenes > DemoScene.unity`.
    -   Press `Play` to test the character movement and camera system.

## Acknowledgments

- [Unity Documentation](https://docs.unity3d.com/)
- [Cinemachine Documentation](https://docs.unity3d.com/Packages/com.unity.cinemachine@latest)
- [Input System Documentation](https://docs.unity3d.com/Packages/com.unity.inputsystem@latest)
