using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToActivate : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    KeyCode button;
    [SerializeField]
    string triggerName;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(button))
        {
            animator.SetTrigger(triggerName);
        }
    }
}
