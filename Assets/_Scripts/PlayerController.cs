using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    
    private CharacterController _controller;
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 playerInput;
    private Vector3 camFoward;
    private Vector3 camRight;
    private Vector3 movePlayer;
    public float playerSpeed;
    public float speedRotation;

    [SerializeField] private bool isRunning;
    public Vector2 maxSpeed;
    public Vector2 maxSpeedDanger;

    [SerializeField] private bool inAimPos;
    [SerializeField] private Weapon fireWeapon;
    private Weapon.weapons currentWeapon;
    
    //Variable temporal testing
    public Material weaponIndicator;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        fireWeapon = FindObjectOfType<Weapon>();
    }
    
    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        //Asiganción de valores según el input
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        playerInput = new Vector3(moveHorizontal, 0, moveVertical);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        
        //Revisar si esta apuntando
        
        if (fireWeapon.weaponType != Weapon.weapons.none)
        {
            if (Input.GetMouseButtonDown(0)) inAimPos = true;
            else if (Input.GetMouseButtonUp(0)) inAimPos = false;
        }
        
        if (inAimPos) //Si esta apuntando no se mueve solo rota
        {
            weaponIndicator.color = Color.blue;
            if (playerInput != Vector3.zero)
            {
                float targetAngle = Mathf.Atan2(playerInput.x, playerInput.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref speedRotation, 0.1f);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (!fireWeapon.meeleAttack)
                {
                    fireWeapon.Shoot();
                }
                else
                {
                    fireWeapon.MeleeAttack();
                }
            }
        }
        else
        {
            weaponIndicator.color = Color.red;
            //Movimiento y rotación según la cámara
            CamDirection();
            movePlayer = (playerInput.x * camRight) + (playerInput.z * camFoward);
            _controller.transform.LookAt(_controller.transform.position + movePlayer);
            _controller.Move(movePlayer * (playerSpeed * Time.deltaTime));
        }
        
        //Gestión de velocidad según el daño.
        if (GameManager.instance.playerLife > 0.5f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) isRunning = true;
            else if (Input.GetKeyUp(KeyCode.LeftShift)) isRunning = false;

            playerSpeed = isRunning ? maxSpeed.y : maxSpeed.x; 
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) isRunning = true;
            else if (Input.GetKeyUp(KeyCode.LeftShift)) isRunning = false;

            playerSpeed = isRunning ? maxSpeedDanger.y : maxSpeedDanger.x;
        }
    }

    public void CamDirection()
    {
        camFoward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camFoward.y = 0;
        camRight.y = 0;

        camFoward = camFoward.normalized;
        camRight = camRight.normalized;
    }
}
