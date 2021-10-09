using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumWindowOpen : MonoBehaviour
{
    public GameObject windowSum;
    public contributsStonksCount data;

    public float percent_per_year;
    public int length_in_mounth;
    public int min_sum;

    public List<Collider2D> deactiveCollider;
    public List<Collider2D> activeCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        CloseOpenWindow();
    }

    public void CloseOpenWindow()
    {
        windowSum.SetActive(!windowSum.activeInHierarchy);
        data.SetInfo(percent_per_year, length_in_mounth, min_sum);
        foreach (Collider2D col in deactiveCollider)
        {
            col.enabled = false;
        }
        foreach (Collider2D col in activeCollider)
        {
            col.enabled = true;
        }
    }

    
}
