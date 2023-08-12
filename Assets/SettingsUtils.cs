using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsUtils : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;

    void Start()
    {
        int levDiff = PlayerPrefs.GetInt("LevelOfDifficulty", 0);
        dropdown.value = levDiff;

        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int newIndex)
    {
        PlayerPrefs.SetInt("LevelOfDifficulty", newIndex);
    }

    private void OnDestroy()
    {
        dropdown.onValueChanged.RemoveListener(OnDropdownValueChanged);
    }
    
    void Update()
    {
        
    }
}
