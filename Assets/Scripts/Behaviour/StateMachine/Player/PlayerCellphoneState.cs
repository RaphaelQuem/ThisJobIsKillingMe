using Assets.Scripts.Behaviour.Model;
using Assets.Scripts.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.StateMachine.Player
{
    public class PlayerCellphoneState : IState
    {
        private PlayerBehaviour _player;
        private Person _target;
        public int currentApp;
        private bool inApp;

        public PlayerCellphoneState(PlayerBehaviour player, Person target)
        {
            player.CellScreen.SetActive(true);
            GameObject.FindGameObjectsWithTag("Thinkbox").ToList().ForEach(tb => tb.SetActive(false));
            Debug.Log("Celphone");
            _player = player;
            _target = target;
            SetIcons(_target);
            currentApp = 0;
        }
        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public Vector2 DirectorVector { get; set; }
        public void Update()
        {
            Actions();
            Move();
        }
        private void Actions()
        {
            if (InputManager.AButton())
            {
                if (inApp)
                    ExecuteOnAppAction();
                else
                    SetApp(currentApp, true);
            }
            if (InputManager.BButton())
            {
                if (inApp)
                {
                    SetApp(currentApp, false);
                }
                else
                {
                    ExitCellScreen();
                }
            }
        }
        private void ExitCellScreen()
        {
            _player.CellScreen.SetActive(false);
            var icons = GameObject.FindGameObjectsWithTag("AppIcon");
            foreach (var icon in icons)
                GameObject.Destroy(icon);
            _player.CurrentState = new PlayerIdleState(_player);
        }
        private void Move()
        {

            Vector2 movVector = InputManager.TImedControllerVector(0.20f, Time.deltaTime);
            if (!inApp)
            {
                if (movVector.x.Equals(1))
                    currentApp = currentApp.Equals(_target.Apps.Count() - 1) ? 0 : currentApp + 1;

                else if (movVector.x.Equals(-1))
                    currentApp = currentApp.Equals(0) ? _target.Apps.Count() - 1 : currentApp - 1;

                _player.Hand.transform.position = new Vector2(_target.Apps[currentApp].IconObject.transform.position.x + .6f, _player.Hand.transform.position.y);
            }
        }
        private void SetApp(int app, bool active)
        {
            inApp = active;
            switch (_target.Apps[app].Name)
            {
                case "CarApp":

                    _player.Holder.GetComponent<GameObjectHolder>().CarApp.SetActive(inApp);
                    break;
                case "SocNet":
                    var socnet = _player.Holder.GetComponent<GameObjectHolder>().Socnet;
                    var nameTxt = _player.Holder.GetComponent<GameObjectHolder>().SocnetNameTxt;
                    var ageTxt = _player.Holder.GetComponent<GameObjectHolder>().SocnetAgeTxt;
                    var friendsTxt = _player.Holder.GetComponent<GameObjectHolder>().SocnetFriendsTxt;

                    nameTxt.text = _target.Name;
                    ageTxt.text =  _target.Age.ToString() + " Anos";
                    friendsTxt.text = _target.Friends.ToString() + " Amigos";



                    socnet.SetActive(inApp);
                    break;
                case "SupChr":
                    _player.Holder.GetComponent<GameObjectHolder>().Supchr.SetActive(inApp);
                    break;
            }
        }
        private void SetIcons(Person target)
        {
            int i = 0;
            foreach (var x in target.Apps)
            {
                GameObject icon = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/icon"));
                icon.transform.position = new Vector2(_player.transform.position.x - 4.75f + (i * 0.6f), icon.transform.position.y);
                target.Apps[i].IconObject = icon;
                i++;
            }
        }    
        private void ExecuteOnAppAction()
        {
            switch (_target.Apps[currentApp].Name)
            {
                case "CarApp":

                    CallCar();
                    break;
                case "SocNet":
                    break;
                case "SupChr":
                    ChargeNow();
                    break;
            }
        }
        private void CallCar()
        {
            GameObject car = (GameObject)Resources.Load("Prefabs/car");
            car.GetComponent<CarBehaviour>().Target = _target.GameObject;
            GameObject.Instantiate(car);
            SetApp(currentApp, false);
            ExitCellScreen();
        }
        private void ChargeNow()
        {
            ExitCellScreen();
            var cloud = (GameObject)Resources.Load("Prefabs/stormyCloud");
            cloud.transform.position = new Vector3(_target.GameObject.transform.position.x, cloud.transform.position.y, -1);
            cloud.GetComponent<StormyCloudBehaviour>().target = _target.GameObject;
            GameObject.Instantiate(cloud);
            SetApp(currentApp, false);
        }
    }
}
