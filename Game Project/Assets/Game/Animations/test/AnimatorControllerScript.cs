using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerScript : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        if (forwardPressed && !isWalking)
        {
            animator.SetBool("isWalking", true);
        } 
        if (!forwardPressed && isWalking)
        {
            animator.SetBool("isWalking", false);
        }
    }
}
