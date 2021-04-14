using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 player;
    private bool groundedPlayer;
    public float playerSpeed;
    public float jumpHeight;
    public float gravityValue;
    public Dialogue dialogue;
    public Animator animator;
    public float speed;

    //Inventory-UI scripts
    [SerializeField] private UI_Inventory uiInventory;


    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        player.y = -0.92f;
        
    }

    void LateUpdate()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && player.y < 0)
        {
            player.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            speed = 30;
        } else {
            speed = 0;
        }

        // Changes the height position of the player
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            player.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        player.y += gravityValue * Time.deltaTime;
        controller.Move(player * Time.deltaTime);

        animator.SetFloat("Speed", speed);
        
    }

    private void OnTriggerEnter(Collider other)  { //Loads certain scenes depeding on which object the character collides with

        if (other.gameObject.tag == "Door") 
        {
            SceneManager.LoadScene("Gym");
        }
        else if (other.gameObject.tag == "NPC")
        {
            FindObjectOfType<DialogueManagerTrivia>().StartDialogue(dialogue);
        }
        else if (other.gameObject.tag == "MJ")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        else if (other.gameObject.tag == "GymDoor")
        {
            SceneManager.LoadScene("Scene2");
        }
        else if (other.gameObject.tag == "Door2")
        {
            SceneManager.LoadScene("Gym2");
        }
    } 
    
}
