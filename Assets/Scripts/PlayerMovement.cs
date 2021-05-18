using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// CharacterController du joueur
    /// </summary>
    public CharacterController controller;

    /// <summary>
    /// Vitesse de marche
    /// </summary>
    public float speed = 7f;

    /// <summary>
    /// Vitesse de course
    /// </summary>
    public float runSpeed = 11f;

    /// <summary>
    /// Force de la gravité
    /// </summary>
    public float gravity = -9.81f;

    /// <summary>
    /// Position du groundCheck
    /// </summary>
    public Transform groundCheck;

    /// <summary>
    /// Buffer autour du groudCheck
    /// </summary>
    public float groundDistance = 0.4f;

    /// <summary>
    /// Mask pour savoir ce qui constitue le sol
    /// </summary>
    public LayerMask groundMask;

    /// <summary>
    /// Animator du joueur
    /// </summary>
    public Animator animator;

    /// <summary>
    /// True = peut bouger, false sinon
    /// </summary>
    public bool canMove = true;

    /// <summary>
    /// Vitesse du joueur
    /// </summary>
    private Vector3 velocity;

    /// <summary>
    /// True = est sur le sol, false sinon
    /// </summary>
    private bool isGrounded;

    private void Awake()
    {
        GameData.player = gameObject;
       
    }

    private void Update()
    {
        if (!canMove || GameData.isMenuOpened || GameData.isUsingKeyPad || !GameData.hasGameStarted) return;
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetButton("Sprint") && z > 0)
        {
            controller.Move(move * (runSpeed * Time.deltaTime));
            animator.SetInteger("Speed", 2);
        }
        else
        {
            controller.Move(move * (speed * Time.deltaTime));
            if (move.magnitude < 0.1)
            {
                animator.SetInteger("Speed", 0);
            }
            else
            {
                animator.SetInteger("Speed", 1);
                if (Mathf.Abs(z) >= Mathf.Abs(x))
                {
                    animator.SetInteger("Direction", z > 0 ? 0 : 2);
                }
                else
                {
                    animator.SetInteger("Direction", x > 0 ? 3 : 1);
                }
            }
        }

      

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    /// <summary>
    /// Snap le joueur à la bonne position selon quelle porte il ouvre et disable son mouvement
    /// </summary>
    public void startOpenDoor()
    {
        canMove = false;
        switch (GameData.doorNumber)
        {
            case 1:
                transform.position = new Vector3(7.524f, -1.374f, 5.14f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                transform.position = new Vector3(9.669f, -1.374f, 8.323f);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case 3:
                transform.position = new Vector3(12.67f, -1.374f, 10.351f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 4:
                transform.position = new Vector3(-10.207f, -1.374f, -1.87f);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
        }
    }

    public void finishOpenDoor()
    {
        canMove = true;
    }

    /// <summary>
    /// Snap le joueur a la bonne position selon quelle porte il essaie d'ouvrir et disable son mouvement
    /// </summary>
    public void startLockDoor()
    {
        canMove = false;
        switch (GameData.doorNumber)
        {
            case 1:
                transform.position = new Vector3(7.74f, -1.374f, 5f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 4:
                transform.position = new Vector3(-10.391f, -1.374f, -2.069f);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
        }
    }

    public void finishLockDoor()
    {
        canMove = true;
    }
}