using UnityEngine;

public class DragonFireSpit : MonoBehaviour
{
    public Animator animator;
    private bool isSpittingFire = false;

    private void Start()
    {
        InvokeRepeating("SetSpittingFire", 0f, 10f);
    }

    private void SetSpittingFire()
    {
        isSpittingFire = true;
        animator.SetBool("isSpittingFire", isSpittingFire);
        Invoke("ResetSpittingFire", 0.5f); // Reset the value after 0.5 seconds to stop the animation
    }

    private void ResetSpittingFire()
    {
        isSpittingFire = false;
        animator.SetBool("isSpittingFire", isSpittingFire);
    }
}
