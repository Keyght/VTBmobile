using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Numpud : MonoBehaviour
{
    int sum;
    public Text sumField;


    public void AddNum(int num)
    {
        sum = sum * 10 + num;
        UpdateField();
    }

    public void DeleteNum()
    {
        sum = sum / 10;
        UpdateField();
    }

    void UpdateField()
    {
        sumField.text = sum.ToString();
    }
}
