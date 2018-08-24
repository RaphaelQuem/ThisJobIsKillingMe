using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpawnManager
{
    
    public static void ClearSpawns()
    {
        string[] tags = new string[] { "Trap", "Animal"};
        foreach (string tag in tags)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tag))
            {
                GameObject.Destroy(obj);

            }
        }
    }

}
