using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject aimOrigin;
    [SerializeField] private Weapon weapon;

    //Variable temporal testing
    public Material weaponIndicator;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        weapon = FindObjectOfType<Weapon>();
    }
    
    void Update()
    {
        ActionPlayer();
    }

    public void ActionPlayer()
    {
        OpenMenus();
        if(Input.GetKeyDown(KeyCode.T)) SceneManager.LoadScene(1);
        
        //Revisar si esta apuntando
        if (Input.GetMouseButtonDown(0)) inAimPos = true;
        else if (Input.GetMouseButtonUp(0)) inAimPos = false;
        if (inAimPos) //Si esta apuntando no se mueve solo rota
        {
            Aim();
            WeaponActions();
        }
        else
        {
            Movement();
        }
    }

    void Movement()
    {
        //Asiganción de valores según el input
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        playerInput = new Vector3(moveHorizontal, 0, moveVertical);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        
        // Mantén la rotación en cero si no hay movimiento vertical
        aimOrigin.transform.localRotation = Quaternion.identity;
        weaponIndicator.color = Color.red;
        
        //Movimiento y rotación según la cámara
        if (playerInput == Vector3.zero)
        {
            CamDirection();
        }
        movePlayer = (playerInput.x * camRight) + (playerInput.z * camFoward);
        _controller.transform.LookAt(_controller.transform.position + movePlayer);
        _controller.Move(movePlayer * (playerSpeed * Time.deltaTime));
        
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

    void Aim()
    {
        //Asiganción de valores según el input
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        playerInput = new Vector3(moveHorizontal, 0, moveVertical);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        
        weaponIndicator.color = Color.blue;
        if (playerInput != Vector3.zero)
        {
            float rotationAmount = moveHorizontal * (speedRotation * Time.deltaTime);
            transform.Rotate(0, rotationAmount, 0);
        }
        if (moveVertical != 0)
        {
            float aimRotationX = moveVertical * -30f; // Ajusta aquí el ángulo según sea necesario
            aimOrigin.transform.localRotation = Quaternion.Euler(aimRotationX, 0, 0);
        }
        else
        {
            // Mantén la rotación en cero si no hay movimiento vertical
            aimOrigin.transform.localRotation = Quaternion.identity;
        }
    }

    void WeaponActions()
    {
        if (Input.GetMouseButtonDown(1)) weapon.UseWeapon();
        if(Input.GetKeyDown(KeyCode.R)) weapon.Reload();
    }
    void OpenMenus()
    {
        if(Input.GetKeyDown(KeyCode.I)) GameManager.instance.OpenInventory();
        if(Input.GetKeyDown(KeyCode.P)) GameManager.instance.Pause();
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
