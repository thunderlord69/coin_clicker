using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class textFade_sc : MonoBehaviour
{
    public float moveSpeed;
    public float fadeSpeed;
    public TextMeshProUGUI textMeshPro;


    void Start()
    {
       
        textMeshPro = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;


        StartCoroutine(FadeImage(textMeshPro, fadeSpeed));
    }

    IEnumerator FadeImage(TextMeshProUGUI textMeshPro, float fadeSpeed)
    {
        for (float i = 1; i >= 0; i -= (fadeSpeed*Time.deltaTime))
        {

            textMeshPro.color = new Color(1, 1, 1, i);
            
            yield return null;
        }
        Destroy(gameObject);
    }

}

