
using UnityEngine;

public class StateMachine
{
    public IdleState idleState;
    public ChaseState chaseState;
    public AttackState attackState;
    public DefendState defendState;
    public DamageState damageState;
    public DeathState deathState;
    public FleeState fleeState;
    public PetrolState patrolState;
    public IState currentState;
    public StateMachine(IAgent agent)
    {
        this.patrolState = new PetrolState(agent);
        this.idleState = new IdleState(agent);
        this.chaseState = new ChaseState(agent);
        this.attackState = new AttackState(agent);
        this.defendState = new DefendState(agent);
        this.damageState = new DamageState(agent);
        this.deathState = new DeathState(agent);
        this.fleeState = new FleeState(agent);
    }
    public void Init(IState startState)
    {
        ChangeState(startState);
    }
    public void ChangeState(IState state)
    {
        if (currentState == state) return;
        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }
    public void Update()
    {
        currentState?.Update();
    }
}











public class IdleState : IState
{
    public IAgent agent;
    public IdleState(IAgent agent)
    {
        this.agent = agent;
    }
    public void Enter()
    {
        Debug.Log(this + " Enter");
    }

    public void Exit()
    {
        Debug.Log("Idle State Exit");
    }

    public void Update()
    {
        Debug.Log("Idle State Update");
        agent.Idle();
    }
}
public class PetrolState : IState
{
    IAgent IAgent;
    public PetrolState(IAgent IAgent)
    {
        this.IAgent = IAgent;
    }
    public void Enter()
    {
        Debug.Log(this + " Enter");
    }
    public void Exit()
    {
        Debug.Log("Patrolling State Exit");
    }
    public void Update()
    {
        Debug.Log("Patrolling State Update");
        IAgent.Petrolling();
    }

}
public class FleeState : IState
{
    IAgent agent;
    public FleeState(IAgent agent)
    {
        this.agent = agent;
    }
    public void Enter()
    {
        Debug.Log(this + " Enter");

    }

    public void Exit()
    {
        Debug.Log(this + " Exit");

    }
    public void Update()
    {
        Debug.Log(this + " Update");
        agent.Flee();
    }
}
public class ChaseState : IState
{
    IAgent agent;
    public ChaseState(IAgent agent)
    {
        this.agent = agent;
    }
    public void Enter()
    {
        Debug.Log(this + " Enter");

    }

    public void Exit()
    {
        Debug.Log(this + " Exit");

    }

    public void Update()
    {
        Debug.Log(this + " Update");
        agent.Chase();
    }
}
public class AttackState : IState
{
    IAgent agent;
    public AttackState(IAgent agent)
    {
        this.agent = agent;
    }
    public void Enter()
    {
        Debug.Log(this + " Enter");

    }
    public void Exit()
    {
        Debug.Log(this + " Exit");

    }
    public void Update()
    {
        agent.Attack();
        Debug.Log(this + " Update");
    }
}
public class DefendState : IState
{
    IAgent agent;
    public DefendState(IAgent agent)
    {
        this.agent = agent;
    }
    public void Enter()
    {
        Debug.Log(this + " Enter");

    }
    public void Exit()
    {
        Debug.Log(this + " Exit");

    }
    public void Update()
    {
        agent.Defend();
        Debug.Log(this + " Update");
    }

}
public class DamageState : IState
{
    IAgent agent;
    public DamageState(IAgent agent)
    {
        this.agent = agent;
    }
    public void Enter()
    {
        agent.Damage();
        Debug.Log(this + " Enter");

    }

    public void Exit()
    {
        Debug.Log(this + " Exit");

    }

    public void Update()
    {
        Debug.Log(this + " Update");
    }

}
public class DeathState : IState
{
    IAgent agent;
    public DeathState(IAgent agent)
    {
        this.agent = agent;
    }

    public void Enter()
    {
        agent.Death();
        Debug.Log(this + " Enter");
    }

    public void Exit()
    {
        Debug.Log(this + " Exit");

    }

    public void Update()
    {
        Debug.Log(this + " Update");

    }
}
public interface IState
{
    public void Enter();
    public void Update();
    public void Exit();
}