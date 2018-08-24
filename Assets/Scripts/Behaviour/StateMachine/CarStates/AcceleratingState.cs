using Assets.Scripts.Behaviour.Model;
using Assets.Scripts.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Behaviour.StateMachine.CarStates
{
    public class AcceleratingState : IState
    {
        Car _car;
        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }
        public Vector2 DirectorVector { get; set; }
        public AcceleratingState(Car car)
        {
            _car = car;
            DirectorVector = _car.Direction.Equals(1) ? Vector3.right : Vector3.left;
        }

        public void Update()
        {
            _car.Self.transform.position =  _car.Self.transform.position + (Vector3)DirectorVector * Time.deltaTime * _car.Speed;
        }
    }
}
