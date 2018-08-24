using Assets.Scripts.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Player
{
    public class PlayerWalkingState : IState
    {
        private PlayerBehaviour _player;
        public PlayerWalkingState(PlayerBehaviour player)
        {
            Debug.Log("Walking");
            _player = player;
        }
        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Vector2 DirectorVector { get; set; }
        public object Colliding { get; private set; }

        public void Update()
        {
            Actions();
            Move();
        }
        private void Actions()
        {
            if (InputManager.BPressed())
            {
                _player.speed = 2.5f;
            }
            else
            {
                _player.speed = 1f;
            }
            if (_player.CanInteract)
            {
                if (InputManager.AButton())
                {
                    _player.CurrentState = new PlayerCellphoneState(_player, _player.Target.GetComponent<PersonBehaviour>().person);
                }
            }
        }
        private void Move()
        {
            Vector2 movVector = InputManager.ControllerHorizontalVector();

            // Dont allow the play to move towards in others objects direction when colliding
            if (movVector.ToDirection().Equals(Colliding))
            {
                movVector = Vector2.zero;
                _player.stateMch.Directorvector = movVector;


                return;
            }
            if (movVector.Equals(Vector2.zero))
            {
                _player.stateMch.Directorvector = Vector2.zero;
                if (_player.CellScreen.activeSelf == false)
                    _player.CurrentState = new PlayerIdleState(_player);
                return;
            }
            _player.stateMch.Directorvector = movVector;
            _player.gameObject.transform.position = _player.gameObject.transform.position + (Vector3)movVector * Time.deltaTime * _player.speed;
        }
    }
}
