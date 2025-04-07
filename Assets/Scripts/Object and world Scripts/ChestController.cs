using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false; // Track if the chest is open
    private bool playerInRange = false;

    private AudioSource audioSource;
    public AudioClip openSound;
    public AudioClip closeSound;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange) // When you press E
        {
            ToggleChest();
            PlaySound();
        }
    }
    void PlaySound()
    {
        if (audioSource != null)
        {
            if (isOpen && openSound != null)
            {
                audioSource.PlayOneShot(openSound);
            }
            else if (!isOpen && closeSound != null)
            {
                audioSource.PlayOneShot(closeSound);
            }
        }
    }
    void ToggleChest()
    {
        isOpen = !isOpen; // Flip the bool (if open, close; if closed, open)
        animator.SetBool("IsOpen", isOpen);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}

