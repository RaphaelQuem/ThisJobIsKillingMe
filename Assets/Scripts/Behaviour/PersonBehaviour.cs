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
using TMPro;

public class PersonBehaviour : MonoBehaviour
{
    public GameObject thinkBox;
    public GameObject thinkBoxBG;
    public Text thoughts;
    public Person person;

    private int currentWFactor =1;

    void Start()
    {
        person = Person.Randomize(gameObject);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = StaticResources.NpcCount++;

    }

    void Update()
    {
        Vector2 movVector = Vector2.zero;
        if (Math.Abs(person.GameObject.transform.position.x - person.DestinationX) > 0.05f)
            movVector = new Vector2(person.DestinationX - person.GameObject.transform.position.x,0);

        movVector.Normalize();
        if (!movVector.Equals(Vector2.zero))
            person.GameObject.transform.position = person.GameObject.transform.position + (Vector3)movVector * Time.deltaTime;

        if (thoughts != null && thoughts.rectTransform != null && thoughts.rectTransform.rect != null)
        {
           var wfactor = (int)(thoughts.rectTransform.rect.width / 2.01f);
            if (wfactor > 0 && currentWFactor != wfactor)
            {
                currentWFactor = wfactor;
                thinkBoxBG.transform.localScale = new Vector3(thinkBoxBG.transform.localScale.x * wfactor,1,1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        thoughts.text = person.Thougths;
        GameObject.FindGameObjectsWithTag("Thinkbox").ToList().ForEach( tb => tb.SetActive(false));
        thinkBox.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        thinkBox.SetActive(false);
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle colision");
    }

}

