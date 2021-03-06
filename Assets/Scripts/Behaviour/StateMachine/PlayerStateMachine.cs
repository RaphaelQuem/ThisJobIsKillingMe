﻿using Assets.Scripts.Extension;
using Assets.Scripts.CodeResource;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.StateMachine
{

    public class PlayerStateMachine
    {
        private float currentStateDuration;
        private ObjectState currentState;
        private Direction currentDirection;
        private Vector2 directorVector;
        private bool isSettingTrap;
        private bool isRolling;
        private Animator animator;
        public Dictionary<ObjectState, float> ActionTime = new Dictionary<ObjectState, float>()
        {
            {ObjectState.Walking,0f},
            {ObjectState.Idle,0f},
            {ObjectState.SettingTrap,0.4f},
            {ObjectState.Rolling,0.5f},
            {ObjectState.Shooting,1f}
        };

        public PlayerStateMachine(Animator anim)
        {
            animator = anim;
            CanSetTrap = true;
            CanRoll = true;
        }
        public ObjectState CurrentState { get { return currentState; } set { currentState = value; } }
        public Direction CurrentDirection { get { return currentDirection; } set { currentDirection = value; } }
        public bool CanSetTrap { get; set; }
        public bool IsSettingTrap
        {
            get
            {
                return isSettingTrap;
            }
            set
            {
                isSettingTrap = value;
                animator.SetBool("isSettingTrap", isSettingTrap);
                if (isSettingTrap)
                {
                    animator.SetTrigger("isSettingTrapTrigger");
                    ChangeCurrentState(ObjectState.SettingTrap);
                }
            }
        }
        public bool CanRoll { get; set; }
        public bool IsRolling
        {
            get
            {
                return isRolling;
            }
            set
            {
                isRolling = value;
                animator.SetBool("isRolling", IsRolling);
                if (IsRolling)
                {
                    animator.SetTrigger("isRollingTrigger");
                    ChangeCurrentState(ObjectState.Rolling);
                }
            }
        }
        public void Kill()
        {
            animator.SetBool("isKilling",true);
            ChangeCurrentState(ObjectState.StealthKill);
        }

        public void Update()
        {
            currentStateDuration += Time.deltaTime;
            float comparer = 0f;
            ActionTime.TryGetValue(CurrentState, out comparer);
            if (comparer > 0f && currentStateDuration > comparer)
            {
                ChangeCurrentState(ObjectState.Idle);
                IsRolling = false;
                IsSettingTrap = false;

                Directorvector = directorVector;
            }

        }

        public Vector2 Directorvector
        {
            get
            {
                return directorVector;
            }
            set
            {
                directorVector = value;
                Update();
                if (CurrentState != ObjectState.Rolling && CurrentState != ObjectState.SettingTrap && CurrentState != ObjectState.Shooting)
                {
                    if (directorVector != Vector2.zero)
                    {
                        //animator.SetFloat("InputX", directorVector.x);
                        //animator.SetFloat("InputY", directorVector.y);
                        //
                        //animator.SetBool("isWalking", true);
                        ChangeCurrentState(ObjectState.Walking);
                        CurrentDirection = directorVector.ToDirection();

                    }
                    else
                    {
                        ChangeCurrentState(ObjectState.Idle);
                        //animator.SetBool("isWalking", false);
                    }
                }
            }
        }

        private void ChangeCurrentState(ObjectState state)
        {
            if (state.Equals(ObjectState.Idle) || state.Equals(ObjectState.Walking))
            {
                CanRoll = true;
                CanSetTrap = true;
            }
            else
            {
                CanRoll = false;
                CanSetTrap = false;
            }
            if (CurrentState != state)
            {
                currentStateDuration = 0;
                CurrentState = state;
            }
        }
    }
}
