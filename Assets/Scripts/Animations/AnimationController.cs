using UnityEngine;

public class AnimationController : Animations
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int IsHit = Animator.StringToHash("IsHit");

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        //controller.OnAttackEvent += Attacking;
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 obj)
    {
        Animator.SetBool(IsWalking, obj.magnitude > .5f);
    }

    //private void Attacking(AttackSO obj)
    //{
    //    Animator.SetTrigger(Attack);
    //}

    private void Hit()
    {
        Animator.SetBool(IsHit, true);
    }

    private void InvincibilityEnd()
    {
        Animator.SetBool(IsHit, false);
    }
}
