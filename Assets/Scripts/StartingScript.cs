using UnityEngine;

public class StartingScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animatorCamera;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private GameObject MoveButton;
    [SerializeField] private GameObject TapButton;

    int numTap = 0;
    [SerializeField] private GameObject[] BoltMassive;
    [SerializeField] private GameObject FirstTap;

    private void Start()
    {
        animatorCamera.Play("Basic");
    }

    public void Tap()
    {
        FirstTap.SetActive(false);
        Destroy(BoltMassive[numTap]);
        numTap++;
        animator.Play($"WheelTraska{numTap}");
        if(numTap == 5)
        {
            animatorCamera.SetBool("Camera", true);
            playerMovement.enabled = true;

            MoveButton.SetActive(true);
            TapButton.SetActive(false);
        }
    }
}
