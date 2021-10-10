using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowListOfGames : MonoBehaviour
{
    public GameObject game1;
    public GameObject game2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnMouseDown()
    {
        game1.SetActive(true);
        game2.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
