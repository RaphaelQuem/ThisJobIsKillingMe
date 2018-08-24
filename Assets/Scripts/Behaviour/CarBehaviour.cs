using Assets.Scripts.Extension;
using Assets.Scripts.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using Assets.Scripts.StateMachine.Player;
using Assets.Scripts.Behaviour.Model;
using Assets.Scripts.Behaviour.StateMachine.CarStates;

public class CarBehaviour : MonoBehaviour
{
    public GameObjectHolder Holder;
    public GameObject Target;
    public float CarSpeed;

    private IState _currentState;
    private Car _car;

    void Start()
    {
        setCar();
        _currentState = new AcceleratingState(_car);
    }

    void Update()
    {
        _currentState.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colidiu");
        if (collision.gameObject.Equals(Target))
            GameObject.Destroy(collision.gameObject);
    }

    private void setCar()
    {
        _car = new Car
        {
            Speed = CarSpeed,
            Self = this.gameObject,
            Target = this.Target,
            Direction = GameObject.FindGameObjectWithTag("Holder").GetComponent<GameObjectHolder>().Randomizer.Next() % 2 == 1? 1:-1
        };
    }

}

