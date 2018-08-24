using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Player
{
    public class PlayerIdleState : IState
    {
        private PlayerBehaviour _player;
        public PlayerIdleState  (PlayerBehaviour player)
        {
            Debug.Log("Idle");
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

        public void Update()
        {
            Actions();
            if (!InputManager.ControllerVector().Equals(Vector2.zero))
                _player.CurrentState = new PlayerWalkingState(_player);

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

    }
}
