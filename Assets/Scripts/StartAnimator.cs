using System.Collections;
using UnityEngine;

public class StartAnimator : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        
        //int randomAnimationIndex = Random.Range(0, 2);
        
        _animator.Play(0);
    }
    

}
