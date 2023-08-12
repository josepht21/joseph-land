using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delivery : MonoBehaviour
{
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private float destroyDelay = 0.1f;
    [SerializeField] PointHUD pointHUD;
    [SerializeField] PackageCounter packageHUD;
    [SerializeField] Timer timer; 

    bool hasPackage = false;
    SpriteRenderer spriteRenderer;
    int initialPackageCount = 0;
    public GameObject completeLevelUI;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
        initialPackageCount = packageHUD.PackageCounterImpl();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Package has been picked.");
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            pointHUD.Points++;

            if(pointHUD.Points == initialPackageCount)
            {
                CompleteLevel();
            }
        }
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        timer.StopTimer();
        timer.CheckBestTime();
        timer.UpdateBestTimeText();
    }
}

