using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Behaviour.Model
{
    
    public class GameObjectHolder:MonoBehaviour
    {
        public GameObject Hand;
        public GameObject CellScreen;
        public GameObject Socnet;
        public GameObject Supchr;
        public Text SocnetNameTxt;
        public Text SocnetAgeTxt;
        public Text SocnetFriendsTxt;
        public GameObject CarApp;
        public System.Random Randomizer = new System.Random(DateTime.Now.Millisecond);
    }
}
