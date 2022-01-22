using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOrderMiniGame : MonoBehaviour
{

    [SerializeField] int nextButton;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject[] myObjects;

    // Start is called before the first frame update
    void Start()
    {
        nextButton = 0;
    }

    private void OnEnable()
    {
        nextButton = 0;
        for (int i = 0; i < myObjects.Length; i++)
        {
            myObjects[i].transform.SetSiblingIndex(Random.Range(0, 9));
        }
    }

    public void ButtonOrder(int button)
    {
        if(button == nextButton)
        {
            if (button == 9)
            {
                nextButton = 0;
                ButtonOrderPanelClose();
                return;
            }
            nextButton++;
        }
        else
        {
            nextButton = 0;
            OnEnable();
        }
    }

    public void ButtonOrderPanelClose()
    {
        GamePanel.SetActive(false);
    }
    
    public void ButtonOrderPanelOpen()
    {
        GamePanel.SetActive(true);
    }

}
