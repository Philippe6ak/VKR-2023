using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class DialogueAnimationController : MonoBehaviour
{
    [System.Serializable]
    public class AnimationData
    {
        public string animationName;
        public AnimationClip animationClip;
    }

    public List<AnimationData> animations = new List<AnimationData>();

    private Animator animator;
    private Dictionary<string, AnimationClip> animationClips = new Dictionary<string, AnimationClip>();

    private void Start()
    {
        animator = GetComponent<Animator>();

        foreach (var animationData in animations)
        {
            if (!animationClips.ContainsKey(animationData.animationName))
            {
                animationClips.Add(animationData.animationName, animationData.animationClip);
            }
        }

        // Play the initial "Idle" animation
        PlayAnimation("Idle");
    }

    public void PlayAnimation(string animationName)
    {
        if (animationClips.ContainsKey(animationName))
        {
            AnimationClip animationClip = animationClips[animationName];
            animator.Play(animationClip.name);
        }
        else
        {
            Debug.LogWarning("Animation not found: " + animationName);
        }
    }

    public void StopAnimation()
    {
        // Stop any active animations and return to the "Idle" animation
        animator.SetTrigger("Idle");
    }
}
