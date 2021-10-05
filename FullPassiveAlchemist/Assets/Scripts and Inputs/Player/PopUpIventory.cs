using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpIventory : MonoBehaviour
{
    public GameObject PopUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger("Close");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopUp(string Text)
    {
        PopUpBox.SetActive(true);
        popUpText.text = Text;
        animator.SetTrigger("Pop");
    }
    public void CloseUp()
    {
        //PopUpBox.SetActive(false);
        animator.SetTrigger("Close");
    }
}
