
using Assets.Scripts.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Behaviour.Model
{
    public class Person
    {
        public GameObject GameObject { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Friends { get; set; }
        public int Street { get; set; }
        public int Apartment { get; set; }
        public int DestinationX { get; set; }
        public string Thougths { get; set; }
        public List<CellphoneApp> Apps { get; set; }


        internal static Person Randomize(GameObject _object)
        {
            CellphoneApp a1 = new CellphoneApp();
            CellphoneApp a2 = new CellphoneApp();
            CellphoneApp a3 = new CellphoneApp();
            List<CellphoneApp> list = new List<CellphoneApp>();

            a1.Name = "SocNet";
            a2.Name = "CarApp";
            a3.Name = "SupChr";


            list.Add(a1);
            list.Add(a2);
            list.Add(a3);
   
            System.Random rnd = new System.Random((int)(UnityEngine.Random.value * 1000));

            string[] names = JsonHelper.getJsonArray<string>(Resources.Load<TextAsset>("RandomSource/MaleNameSource").text);
            string[] surnames = JsonHelper.getJsonArray<string>(Resources.Load<TextAsset>("RandomSource/SurnameSource").text);



            var rangeChance = rnd.Next(1, 100);
            Person result = new Person
            {
                Age = StaticResources.Randomize((int)(UnityEngine.Random.value * 1000), rnd.Next(1, 100), 70, 17, 45, 85, 46, 59, 100, 60, 78),
                Apps = list,
                Name = string.Concat(names[rnd.Next(1, 1000)], " ",surnames[rnd.Next(1, 1000)]).ToTitleCase(),
                Friends = StaticResources.Randomize((int)(UnityEngine.Random.value * 1000), rnd.Next(1, 100), 70, 17, 220, 85, 221, 5050, 100, 5050, 200000),
                DestinationX = StaticResources.Randomize((int)(UnityEngine.Random.value * 1000), rnd.Next(1, 100), 100, -11,11),
                GameObject = _object
            };


            switch (rnd.Next(1, 4))
            {
                case 1:
                    result.Thougths = "HOJE EU VOU FUDER ATÈ O TALO";
                    break;
                case 2:
                    result.Thougths = "Tenho que comprar o leite das crianças guatemaltecas";
                    break;
                case 3:
                    result.Thougths = "HOje eu vou fude muito";
                    break;
                default:
                    result.Thougths = "Nem adianta botar";
                    break;
            }
            return result;
        }

    }
}
