using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram : MonoBehaviour
{
    public GameObject[] texts = new GameObject[4];
    void Start()
    {
        StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        bool done = false;
        while (!done)
        {
            float number = Random.Range(0f, 1f);
            if (number < 0.05)
            {
                texts[3].SetActive(true);
                yield return new WaitForSeconds(2);
                texts[3].SetActive(false);
            }
            else if (number < 0.1)
            {
                texts[2].SetActive(true);
                yield return new WaitForSeconds(2);
                texts[2].SetActive(false);
            }
            else if (number < 0.5)
            {
                texts[1].SetActive(true);
                yield return new WaitForSeconds(2);
                texts[1].SetActive(false);
            }
            else
            {
                texts[0].SetActive(true);
                yield return new WaitForSeconds(2);
                texts[0].SetActive(false);
            }

            yield return new WaitForSeconds(5);
        }
    }
}
