using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Controller.Inputs 
{
    [RequireComponent(typeof(PlayerMovement))]

    public class Controller : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _aim;
        [SerializeField] private float _forceJump = 5f;
        [SerializeField] private float _mouseTurnSpeed = 10f;

        private Vector3 movement;
        private PlayerMovement playerMovement;
        private bool isGrounded;

        void Start()
        {
            PlayerManager.CurrentPlayer = transform;
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            HandleJump();
        }

        private void FixedUpdate()
        {          
            playerMovement.MoveCharacter(movement);
            RotateToMouse();
            HandleMovement();
        }

        void HandleJump()
        {
            if (Input.GetButtonDown(GlobalVars.JumpButton) && isGrounded)
            {
                playerMovement.JumpCharacter(_forceJump);
                movement *= 4f;
            }
        }

        void HandleMovement()
        {
            float horizontal = Input.GetAxis(GlobalVars.HorizontalAxis);
            float vertical = Input.GetAxis(GlobalVars.VerticalAxis);

            Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;

            if (movement != Vector3.zero)
            {
                Vector3 finalMovement = _camera.TransformDirection(movement);
                this.movement = finalMovement.normalized;
            }

            else
            {
                this.movement = Vector3.zero;
            }
        }

        void RotateToMouse()
        {
            Vector3 mousePosScreen = Input.mousePosition;

            Plane plane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(mousePosScreen);
            float distance;

            if (plane.Raycast(ray, out distance))
            {
                Vector3 pointOnPlane = ray.GetPoint(distance);
                _aim.position = pointOnPlane;
                Vector3 direction = (pointOnPlane - transform.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _mouseTurnSpeed);
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

            if (angle < 45f)
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            isGrounded = false;
        }
    }
}