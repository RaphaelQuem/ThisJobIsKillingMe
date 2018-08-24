using Assets.Scripts.Extension;
using Assets.Scripts.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using Assets.Scripts.StateMachine.Player;


public class PlayerBehaviour : MonoBehaviour
{
    public bool CanInteract { get; set; }

    private Rigidbody2D rbody;
    private Animator anim;
    public PlayerStateMachine stateMch;
    public GameObject CellScreen;
    public GameObject Hand;
    public GameObject ActionTarget { get; set; }
    public GameObject Holder;
    public float speed;
    public GameObject Target { get; set; }
    

    public IState CurrentState;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        stateMch = new PlayerStateMachine(anim);
        CurrentState = new PlayerWalkingState(this);
    }

    void Update()
    {
        CurrentState.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CanInteract = true;
        Target = collision.gameObject;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject != Target)
        {
            CanInteract = true;
            Target = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CanInteract = false;

    }
}

