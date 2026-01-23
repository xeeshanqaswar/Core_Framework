using UnityEngine;
using UnityEngine.UI;
using System;

public class ConsentView : MonoBehaviour
{
    public Button acceptButton;
    public Button declineButton;

    
    
    public void Setup(Action<bool> onComplete)
    {
        acceptButton.onClick.AddListener(() =>
        {
            onComplete(true);
            gameObject.SetActive(false);
        });
        
        declineButton.onClick.AddListener(() =>
        {
            onComplete(false);
            gameObject.SetActive(false);
        });
    }
    
    
    
}
