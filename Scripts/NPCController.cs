using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Animator animator;
    private bool isTalking = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetTalking(bool state)
    {
        isTalking = state;
        if (animator != null)
        {
            animator.SetBool("isTalking", state);
        }
    }

    public void LookAtPlayer(Transform player)
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        if (direction.magnitude > 0.1f)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 2f);
    }
}
