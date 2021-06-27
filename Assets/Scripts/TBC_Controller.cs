using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBC_Controller : MonoBehaviour
{
    public RectTransform myRect;
    protected float endVal = 2040f;
    protected float speed = 80f;

    private void Awake()
    {
        myRect = transform.Find("CreditsShell").GetComponent<RectTransform>();
    }

    private void Start()
    {
        //Destroy the package
        GameObject p = GameObject.Find("The Package");
        if (p != null) Destroy(p);
        StartCoroutine(CreditsRun());
    }

    IEnumerator CreditsRun()
    {
        //1. Wait for seconds
        yield return new WaitForSeconds(2.5f);
        //2. Begin scroll
        while(myRect.anchoredPosition.y < endVal)
        {
            Vector2 newVec = myRect.anchoredPosition;
            newVec += new Vector2(0, speed * Time.deltaTime);
            newVec.y = Mathf.Clamp(newVec.y, 0, endVal);
            myRect.anchoredPosition = newVec;
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        SceneController.Instance.GoToScene("TitleScreen");

    }
}
