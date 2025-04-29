using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected Animator _animator;

    protected float _speed;
    protected virtual void Movement()
    {

    }
}
