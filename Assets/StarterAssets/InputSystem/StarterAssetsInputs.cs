using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		//Custom
		public bool attack;
		public bool rolling;

		private static StarterAssetsInputs instance = null;

		public static StarterAssetsInputs Instance
		{
			get
			{
				if (instance == null)
				{
					var instance = GameObject.FindObjectOfType<StarterAssetsInputs>();
					if (instance == null)
					{
						GameObject obj = new GameObject("Unity Singleton");
						instance = obj.AddComponent<StarterAssetsInputs>();
					}
				}
			return instance;
			}	
		}

		void Awake() {
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(this.gameObject);
			}
			else
			{
				Destroy(gameObject);
			}	
		}

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		//Custom
		public void OnAttack(InputValue value)
		{
			AttackInput(value.isPressed);
		}

		public void OnRolling(InputValue value)
		{
			RollingInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
		
		//Custom
		public void AttackInput(bool newAttackState)
		{
		   attack = newAttackState;
		}

		public void RollingInput(bool newRollingState)
		{
		   rolling = newRollingState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
		
		//Custom
		private void Update() {
			sprint = Mathf.Abs(move.x) >= 1 || Mathf.Abs(move.y) >=1;
		}
	}
	
}