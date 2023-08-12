using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageCounter : MonoBehaviour
{
    [SerializeField] Text packagesText;

    private void Awake() 
    {
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        int packageCount = PackageCounterImpl();
        packagesText.text = packageCount.ToString();
    }

    public GameObject[] RetrievePackages()
    {
        GameObject[] packages = GameObject.FindGameObjectsWithTag("Package");
        return packages;
    }

    public int PackageCounterImpl()
    {
        GameObject[] packages = RetrievePackages();
        int packageCount = packages.Length;  
        return packageCount;    
    }
}
