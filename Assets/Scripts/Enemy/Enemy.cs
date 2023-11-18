using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public EnemyStateMachine stateMachine;
    [HideInInspector] public IdleState idle;
    [HideInInspector] public PatrolState patrol;
    [HideInInspector] public AttackState attack;
    [HideInInspector] public DetectState detect;

    [SerializeField] protected int health;
    [SerializeField] protected int reward;
    public int damage;

    public Player player;
    public Transform playerPos; //Позиция игрока
    public float detectDistance; //Расстояние когда враг заметит игрока
    public float loseDistance; //Расстояние когда враг отпустит игрока
    public float attackDistance; // Расстояние чтобы ударить игрока
    public float _speed;
    public List<GameObject> _pointPatrol;
    public bool mFacingRight = false;
    public bool isAttacking = false;
    public int walkAnim = Animator.StringToHash("IsWalk");
    public int attackAnim = Animator.StringToHash("IsAttack");

    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
            playerPos = player.transform;

        stateMachine = new EnemyStateMachine();

       // idle = new IdleState(this, stateMachine);
        patrol = new PatrolState(this, stateMachine);
        attack = new AttackState(this, stateMachine);
        detect = new DetectState(this, stateMachine);

        stateMachine.Init(patrol);
    }

    private void Update()
    {
        stateMachine.currentState.HandleInput();

        stateMachine.currentState.UpdateLogic();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.UpdatePhysics();
    }

    private void Flip()
    {
        mFacingRight = !mFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void OnFlip(bool value)
    {
        if (value == true && mFacingRight)
            Flip();

        if (value == false && !mFacingRight)
            Flip();
    }

    public void SetBoolAnimation(int param, bool value)
    {
        _animator.SetBool(param, value);
    }
}
