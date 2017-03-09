using UnityEngine;
using System.Collections;

public enum AiState { Idle, Chase, Stunned}

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour {

    public float idleSpeed = 1;
    public float chaseSpeed = 5;
    public float changePatrolPointTimer = 5;
    public float patrolRange = 5;
    public float viewDistance = 2;
    public float viewAngle = 90;

    float velocity;
    AiState curState;
    Light chaseLight;
    NavMeshAgent agent;
    GameManager _gameManager;
    Coroutine curRoutine;

    void Awake()
    {
        _gameManager = GeneralMethods.GetGameManager();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        chaseLight = GetComponent<Light>();
        ChangeState(AiState.Idle);
    }

    void Update()
    {
        if (curState != AiState.Stunned)
        {
            if (HasSight()) //Can the enemy see the player and is not in a stunned state
            {
                ChangeState(AiState.Chase);
            }
            else if (curState != AiState.Idle) //Is the enemy unable to see the player and is not yet idle or stunned
            {
                ChangeState(AiState.Idle);
            }
        }

        if (curState != AiState.Chase && chaseLight != null)
        {
            chaseLight.intensity = Mathf.SmoothDamp(chaseLight.intensity, 0, ref velocity, 0.1f);
        }
    }

    void ChangeState(AiState newState)
    {
        curState = newState; //Store the state for checking when to look for the player

        if (curRoutine != null) //Make sure you stop the old coroutine before starting a new one
        {
            StopCoroutine(curRoutine);
        }

        switch (newState)
        {
            case AiState.Idle:
                agent.speed = idleSpeed;
                curRoutine = StartCoroutine(Patrol());
                break;
            case AiState.Chase:
                agent.speed = chaseSpeed;
                MoveToTarget(_gameManager.playerManager.playerWorldReferance.transform.position);

                if (chaseLight != null)
                {
                    chaseLight.intensity = Mathf.SmoothDamp(chaseLight.intensity, 1, ref velocity, 0.1f);
                }

                if (Vector3.Distance(transform.position, _gameManager.playerManager.playerWorldReferance.transform.position) <= 1)
                {
                    _gameManager.soundManager.PlayJumpScareSound();
                    _gameManager.playerManager.RespawnPlayer();
                }
                break;
            case AiState.Stunned:
                curRoutine = StartCoroutine(StunLoop());
                break;
        }
    }

    Vector3 PatrolPos()
    {
        float x = Random.Range(-patrolRange / 2, patrolRange / 2);
        float z = Random.Range(-patrolRange / 2, patrolRange / 2);

        Vector3 newPos = transform.position + new Vector3(x, 0, z);

        return newPos;
    }

    bool HasSight()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, viewDistance);

        foreach (Collider c in cols)
        {
            if (c.tag == "Player")
            {
                Vector3 direction = c.gameObject.transform.position - transform.position;
                Ray ray = new Ray(transform.position, direction);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, viewDistance))
                {
                    if (hit.collider.tag == "Player")
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    IEnumerator Patrol()
    {
        MoveToTarget(PatrolPos());
        yield return new WaitForSeconds(changePatrolPointTimer);
        ChangeState(AiState.Idle); //Keep it looping
    }

    IEnumerator StunLoop()
    {
        MoveToTarget(transform.position);
        yield return new WaitForSeconds(0.5f);
        curState = AiState.Idle; //If the Stun methos has not been called in 0.5 seconds then go back to idle (Wish I could do this better)
    }

    void MoveToTarget(Vector3 target)
    {
        agent.SetDestination(target);
    }

    public void Stun()
    {
        ChangeState(AiState.Stunned);
    }
}

