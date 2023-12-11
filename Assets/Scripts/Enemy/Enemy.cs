using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    #region Variables

    [HideInInspector] public EnemyStateMachine stateMachine;
    [HideInInspector] public IdleState idle;
    [HideInInspector] public PatrolState patrol;
    [HideInInspector] public AttackState attack;
    [HideInInspector] public DetectState detect;
    [HideInInspector] public HurtState hurt;

    [SerializeField] private Player _player;
    public Player Target => _player;

    public int health;
    public int reward;
    public int damage;
    public float timerAttack;
    public float speed;
    public bool mFacingRight = false;

    public Transform playerPos; //Позиция игрока

    public float detectDistance; //Расстояние когда враг заметит игрока
    public float loseDistance; //Расстояние когда враг отпустит игрока
    public float attackDistance; // Расстояние чтобы ударить игрока

    public List<GameObject> _pointPatrol;

    public int walkAnim = Animator.StringToHash("IsWalk");
    public int attackAnim = Animator.StringToHash("IsAttack");
    public int hurtAnim = Animator.StringToHash("IsHurt");

    private int _currentHealth;
    private Animator _animator;

    public UnityAction<int, int> HealthChanged;
    #endregion

    private void Start()
    {
        _currentHealth = health;
        _animator = GetComponent<Animator>();

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
            playerPos = player.transform;

        stateMachine = new EnemyStateMachine();

       // idle = new IdleState(this, stateMachine);
        patrol = new PatrolState(this, stateMachine);
        attack = new AttackState(this, stateMachine);
        detect = new DetectState(this, stateMachine);
        hurt = new HurtState(this, stateMachine);

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

    public void TakeDamage(int damage)
    {
        stateMachine.ChangeState(hurt);

        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, health);

        if(_currentHealth <= 0)
        {
            _player.AddMoney(reward);

            Destroy(gameObject);
        }
    }
}
