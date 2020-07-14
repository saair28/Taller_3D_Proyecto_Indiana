﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    [System.Serializable]
    public class Dropeo
    {
        public string name;
        public GameObject objeto;
        public int probabilidad;
    }

    public List <Dropeo> LootTable = new List<Dropeo>();

    public int dropChance;

    public bool dropea = false;

    public bool Cumplirfuncion = true;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dropea = player.GetComponent<Player>().abrir;

        if (dropea == true && Cumplirfuncion == true)
        {
            CalcularDropeo();
        }
        else
        {
        }

    }

    public void CalcularDropeo()
    {
        int calc_dropChance = Random.Range(0, 101);

        if (calc_dropChance > dropChance)
        {
            Debug.Log("No hay loot para ti");
            return;
        }

        if (calc_dropChance <= dropChance)
        {
            int itemWeight = 0;

            for (int i = 0; i < LootTable.Count; i++)
            {
                itemWeight += LootTable[i].probabilidad;
            }
            Debug.Log("itemWeigth =" + itemWeight);

            int RandomValue = Random.Range(0, itemWeight);

            for (int j = 0; j < LootTable.Count; j++)
            {
                if (RandomValue <= LootTable[j].probabilidad)
                {
                    Instantiate(LootTable[j].objeto, transform.position, Quaternion.identity);
                }
            }

            Cumplirfuncion = false;
        }
    }
}
