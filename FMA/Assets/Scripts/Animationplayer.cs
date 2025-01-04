using UnityEngine;
using UnityEngine.UI;

public class AnimationControl : MonoBehaviour
{
    public Animator animator; // Assign your Animator component here
    public Button playToKeyframeButton; // Button to play to the keyframe
    public Button continueAnimationButton; // Button to continue the animation

    private bool isPlayingToKeyframe = false;
    private float keyframeTime = 2.5f; // Time in seconds to which the animation should play

    void Start()
    {
        playToKeyframeButton.onClick.AddListener(PlayToKeyframe);
        continueAnimationButton.onClick.AddListener(ContinueAnimation);
    }

    public void PlayToKeyframe()
    {
        if (!isPlayingToKeyframe)
        {
            // Stop the animation if it's currently playing
            animator.speed = 0;
            animator.Play("leftmove", 0, 0f); // Start the animation from the beginning
            animator.speed = 1; // Set speed back to normal
            animator.Play("leftmove", 0, keyframeTime); // Play to the desired keyframe
            isPlayingToKeyframe = true;
        }
    }

    public void ContinueAnimation()
    {
        if (isPlayingToKeyframe)
        {
            animator.speed = 1; // Resume the animation from where it left off
            isPlayingToKeyframe = false;
        }
    }
}

