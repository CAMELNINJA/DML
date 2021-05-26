using UnityEngine;

namespace Player
{
    public sealed class Playertransform : MonoBehaviour
    {

        [Header("Locomotion Settings")] 
        [SerializeField]
        private float runSpeed;
        
        [SerializeField]
        private float jumpForce;


            // Action keys.
        [Header("Action Keys")]
        [SerializeField]
        private KeyCode walkKey;

        [SerializeField]
        private KeyCode sprintKey;
    
        // Stored required components.
        private CharacterController _characterController;

    
        private Vector2 _input;
        private Vector3 _moveDirection;
        // Start is called before the first frame update
        void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            ReadInput();
            CalculateCharacterDirection();
            ApplyGravity();
            ApplyMovement();
        }

        private void ReadInput()=> _input=new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));


        private void  CalculateCharacterDirection()
        {

            var speed = runSpeed;
         
            var forward = transform.right * speed;
            var rigth = transform.forward * speed;
            forward *= _input.x;
            rigth *= _input.y;
            _moveDirection = forward +rigth ;
        }

        private void ApplyMovement()=>_characterController.Move(_moveDirection * Time.deltaTime);

        private void ApplyGravity()
        {
            if (!_characterController.isGrounded)
            {
                var gravitySpeed = 12f;
                _moveDirection += Physics.gravity * gravitySpeed * Time.deltaTime;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    
                    _moveDirection.y = jumpForce;
                }
            }
        }
    }
}
