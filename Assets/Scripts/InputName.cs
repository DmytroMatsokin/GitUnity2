using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    InputField inpF;
    // Start is called before the first frame update
    void Start()
    {
        inpF = gameObject.GetComponent<InputField>();
        
        inpF.onEndEdit.AddListener(delegate { GetName(inpF); });

        inpF.text = GameManager.Instance.userName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  GetName(InputField input)
    {

        GameManager.Instance.userName = inpF.text;
        //Debug.Log(inpF.text);
    }
}
