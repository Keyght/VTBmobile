using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButtons : MonoBehaviour
{
    public Animator anim;
    public Animator subMenu;
    // Start is called before the first frame update
    void Start()
    {
        // anim.GetComponentInParent<Animator>();
        subMenu.SetBool("Hide", true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        anim.SetBool("Hide", true);
        subMenu.gameObject.SetActive(true);
        subMenu.SetBool("Hide", false);
    }
}
