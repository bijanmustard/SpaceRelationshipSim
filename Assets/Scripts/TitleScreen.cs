using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    GameObject war, love, what;
    protected float delay = 0.75f;

    private void Awake()
    {
        war = transform.Find("War").gameObject;
        love = transform.Find("Love").gameObject;
        what = transform.Find("What").gameObject;
        war.SetActive(false);
        love.SetActive(false);
        what.SetActive(false);
       
    }

    private void Start()
    {
        StartCoroutine(TitleSeq());
    }

    IEnumerator TitleSeq()
    {
        yield return new WaitForSeconds(1f);
        love.SetActive(true);
        yield return new WaitForSeconds(delay);
        war.SetActive(true);
        yield return new WaitForSeconds(delay);
        what.SetActive(true);
        yield return new WaitForSeconds(delay * 2);
        SceneController.Instance.GoToScene("Plaza");
    }
}
