using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Behaviour.Model
{
    public class Car
    {
        public float Speed {get;set;}
        public GameObject Self { get; set; }
        public GameObject Target { get; set; }
        public int Direction { get;set; }

    }
}
