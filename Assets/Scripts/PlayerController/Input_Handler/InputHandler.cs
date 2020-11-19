using UnityEngine;

namespace VHS
{
    public class InputHandler : MonoBehaviour
    {
        #region Data
        [Space, Header("Input Data")]
        [SerializeField] private CameraInputData cameraInputData = null;
        [SerializeField] private MovementInputData movementInputData = null;
        [SerializeField] private InteractionInputData interactionInputData = null;
        #endregion

        #region BuiltIn Methods
        private void Start()
        {
            ResetInputData();
        }

        private void Update()
        {
            GetCameraInput();
            GetMovementInputData();
            //GetInteractionInputData();
        }
        #endregion

        public void ResetInputData()
        {
            cameraInputData.ResetInput();
            movementInputData.ResetInput();
            //interactionInputData.ResetInput();
        }

        #region Custom Methods
        private void GetInteractionInputData()
        {
            interactionInputData.InteractedClicked = Input.GetKeyDown(KeyCode.E);
            interactionInputData.InteractedReleased = Input.GetKeyUp(KeyCode.E);
        }

        private void GetCameraInput()
        {
            cameraInputData.InputVectorX = Input.GetAxis("Mouse X");
            cameraInputData.InputVectorY = Input.GetAxis("Mouse Y");

            cameraInputData.ZoomClicked = Input.GetKeyDown(KeyCode.LeftShift);
            cameraInputData.ZoomReleased = Input.GetKeyUp(KeyCode.LeftShift);

            //cameraInputData.ZoomClicked = Input.GetMouseButtonDown(1);
            //cameraInputData.ZoomReleased = Input.GetMouseButtonUp(1);
        }

        private void GetMovementInputData()
        {
            movementInputData.InputVectorX = Input.GetAxisRaw("Horizontal");
            movementInputData.InputVectorY = Input.GetAxisRaw("Vertical");

            /*
               movementInputData.RunClicked = Input.GetKeyDown(KeyCode.LeftShift);
               movementInputData.RunReleased = Input.GetKeyUp(KeyCode.LeftShift);

                if(movementInputData.RunClicked)
                    movementInputData.IsRunning = true;

                if(movementInputData.RunReleased)
                    movementInputData.IsRunning = false;

                movementInputData.JumpClicked = Input.GetKeyDown(KeyCode.Space);
                movementInputData.CrouchClicked = Input.GetKeyDown(KeyCode.LeftControl);
            */
        }
        #endregion
    }
}