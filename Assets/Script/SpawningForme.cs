using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningForme : MonoBehaviour
{
    public GameObject[] Formes;
    public GameObject Main;
    // Start is called before the first frame update
    void Start()
    {
        NewForme();
    }

    // Update is called once per frame
    public void NewForme()
    {
        if (Main.GetComponent<Main>().NbrForme < 5)
        {
            Instantiate(Formes[Random.Range(0, Formes.Length)], transform.position, Quaternion.identity);
            Main.GetComponent<Main>().NbrForme++;
        }
    }
}
