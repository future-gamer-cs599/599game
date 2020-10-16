using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using TMPro;

public class LevelSelectorScreen : MonoBehaviour
{
    public GameObject levelHolder;
    public GameObject levelButton;
    public GameObject thisCanvas;
    public int numberOfLevels = 5;
    public Vector2 buttonSpacing;
    public bool unlockLevels;
    
    private Rect panelDimensions;
    private Rect buttonDimensions;
    private int amountPerPage;
    private int currentLevelCount;
    private List<GameObject> levelButtons = new List<GameObject> ();
    
    // Start is called before the first frame update
    void Start()
    {
        panelDimensions = levelHolder.GetComponent<RectTransform>().rect;
        buttonDimensions = levelButton.GetComponent<RectTransform>().rect;
        int maxInARow = Mathf.FloorToInt((panelDimensions.width + buttonSpacing.x) / (buttonDimensions.width + buttonSpacing.x));
        int maxInACol = Mathf.FloorToInt((panelDimensions.height + buttonSpacing.y) / (buttonDimensions.height + buttonSpacing.y));
        amountPerPage = maxInARow * maxInACol;
        int totalPages = Mathf.CeilToInt((float)numberOfLevels / amountPerPage);
        LoadPanels(totalPages);
        InitializeLevels();
    }

    void LoadPanels(int numberOfPanels){
        GameObject panelClone = Instantiate(levelHolder) as GameObject;
        // PageSwiper swiper = levelHolder.AddComponent<PageSwiper>();
        // swiper.totalPages = numberOfPanels;

        for(int i = 1; i <= numberOfPanels; i++){
            GameObject panel = Instantiate(panelClone) as GameObject;
            panel.transform.SetParent(thisCanvas.transform, false);
            panel.transform.SetParent(levelHolder.transform);
            panel.name = "Page-" + i;
            panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i-1), 0);
            SetUpGrid(panel);
            int numberOfButtons = i == numberOfPanels ? numberOfLevels - currentLevelCount : amountPerPage;
            LoadButtons(numberOfButtons, panel);
        }
        Destroy(panelClone);
    }

    void SetUpGrid(GameObject panel){
        GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(buttonDimensions.width, buttonDimensions.height);
        grid.childAlignment = TextAnchor.MiddleCenter;
        grid.spacing = buttonSpacing;
    }

    void LoadButtons(int numberOfButtons, GameObject parentObject){
        for(int i = 1; i <= numberOfButtons; i++){
            currentLevelCount++;
            GameObject button = Instantiate(levelButton) as GameObject;
            button.transform.SetParent(thisCanvas.transform, false);
            button.transform.SetParent(parentObject.transform);
            button.name = i.ToString();
            button.GetComponentInChildren<Text>().text = currentLevelCount.ToString();
            levelButtons.Add(button);
        }
    }

    void InitializeLevels() {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for (int i = 0; i < levelButtons.Count; i++) {
            Button btn = levelButtons[i].GetComponent<Button>();
            
            // On click load level
            btn.onClick.AddListener(delegate{ LinkLevel(btn); });
            
            // Lock levels except first
            if (!unlockLevels) {
                if (i + 1 > levelAt) {
                    btn.interactable = false;
                }
            }
        }         
    }

    void LinkLevel(Button levelButton) {
        int levelNum = Convert.ToInt32(levelButton.name);

        //// Analytics Log: level open
        AnalyticsResult openAnalytics = Analytics.CustomEvent(
            "LevelOpen", new Dictionary<string, object> {
                { "Level", levelButton.name}
            }
        );

        // Debug: analytics
        Debug.Log("CustomEvent LevelOpen sent: " + openAnalytics);
        Debug.Log(levelButton.name);

        SceneManager.LoadScene(levelNum + 1);
    }
}
