using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Essa é a mira do jogo
public class targetScript : MonoBehaviour
{
    public static targetScript ScriptTarget;

    [SerializeField] private TMP_Text targetText;
    // Start is called before the first frame update

    private void Awake()
    {
        ScriptTarget = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setText(string txt)
    {
        targetText.text = txt;
    }
}
