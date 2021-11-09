using UnityEngine;
using System.Collections;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
   [SerializeField] private float activationDelay;
   [SerializeField] private float activeTime;
   private Animator anim;
   private SpriteRenderer spriteRend;

    private bool triggered; // when player trigger the trap
    private bool active; // when trap gets active and player now can get hurt

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
                StartCoroutine(ActivateFiretrap());

            if (active)
                collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
    private IEnumerator ActivateFiretrap()
    {
        // turn the sprite red to make sure player and trigger trap is notified
        triggered = true;
        spriteRend.color = Color.red; 

        //wait for the delay, active trap, turn on animation, return color back to normal
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; // turn the sprite back to initial color
        active = true;
        anim.SetBool("activated", true);

        //wait until X seconds, deactivate trap and reset all variables and animator
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }

}
