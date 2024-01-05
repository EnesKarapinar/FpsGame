using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public CharacterController cc;
    public float speed = 10f;
    public float gravity = -40f;
    public int playerHealth = 100;

    private Vector3 gravityVector;

    // GroundCheck
    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.35f;
    public LayerMask groundLayer;

    public bool isGrounded = false;
    public float jumpSpeed = 2f;

    // UI
    public Slider healthSlider;
    public Text healthText;
    public CanvasGroup damageScreenUI;

    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        damageScreenUI = GameObject.Find("DamageUIPanel").GetComponent<CanvasGroup>();
        gameManagerScript = FindObjectOfType<GameManager>();
        damageScreenUI.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        GroundCheck();
        JumpAndGravity();
        DamageScreenCleaner();
    }

    void MovePlayer()
    {
        Vector3 moveVector = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;

        cc.Move(moveVector * speed * Time.deltaTime);
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }

    void JumpAndGravity()
    {
        gravityVector.y += gravity * Time.deltaTime;
        cc.Move(gravityVector * Time.deltaTime);

        if(isGrounded && gravityVector.y < 0)
        {
            gravityVector.y = -3f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            gravityVector.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
        }
    }

    public void PlayerTakeDamage(int DamageAmount)
    {
        playerHealth -= DamageAmount;
        healthSlider.value -= DamageAmount;
        HealthTextUpdate();
        damageScreenUI.alpha = 1f;

        if(playerHealth <= 0)
        {
            PlayerDeath();
            HealthTextUpdate();
            healthSlider.value = 0;
        }
    }
    
    void PlayerDeath()
    {
        gameManagerScript.RestartGame();
    }

    void HealthTextUpdate()
    {
        healthText.text = playerHealth.ToString();
    }

    void DamageScreenCleaner()
    {
        if(damageScreenUI.alpha > 0)
        {
            damageScreenUI.alpha -= Time.deltaTime;
        }
    }
}
