using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapControl : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private MapSounds mapSounds;
    [SerializeField] private Button[] arrBtnLocation;
    [SerializeField] private Text txtTitle;
    [SerializeField] private Text txtNameNPC;
    [SerializeField] private Text txtDescr;
    [SerializeField] private Button btnNext;
    [SerializeField] private Button btnEnter;

    private List<DayInfo> listDays = new List<DayInfo>();
    private int currentDay = 0;
    private int currentLocationIndex = -1;
    private Color[] arButtonColors = new Color[] { Color.green, new Color(1f, 0.7f, 0.3f), Color.red, Color.gray };

    // Start is called before the first frame update
    void Start()
    {
        GenerateListDay();
        if (int.TryParse(GameManager.Instance.currentDay, out int numDay))
        {
            currentDay = numDay - 1;
        }
        else currentDay = 0;
        SetDayButtons();
        btnNext.interactable = false;
        btnEnter.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDayButtons()
    {
        DayInfo di = GetDayInfo(currentDay);
        if (di != null)
        {
            infoPanel.transform.GetChild(0).GetComponent<Text>().text = di.HelpDay;
            infoPanel.SetActive(true);
            foreach(Button btn in arrBtnLocation)
            {
                bool isOn = false;
                string title = btn.gameObject.GetComponent<LocationButtonControl>().Title;
                foreach(LocationInfo li in di.ListLocations)
                {
                    if (title == li.Title)
                    {
                        btn.transform.GetChild(1).gameObject.GetComponent<Text>().text = title;
                        btn.transform.GetChild(2).gameObject.GetComponent<Text>().text = li.NumberDay.ToString();
                        btn.interactable = true;
                        btn.gameObject.GetComponent<Image>().color = arButtonColors[1];
                        isOn = true;
                        break;
                    }
                }
                if (isOn == false)
                {
                    btn.transform.GetChild(1).gameObject.GetComponent<Text>().text = title;
                    btn.gameObject.GetComponent<Image>().color = arButtonColors[3];
                    btn.interactable = false;
                }
            }
        }
        btnNext.interactable = false;
        txtTitle.text = "";
        txtNameNPC.text = "";
        txtDescr.text = "";
    }

    private void GenerateListDay()
    {
        listDays.Add(new DayInfo(1, "�������� ����, ����� �������� � ���������.", new List<LocationInfo>()
        {
            new LocationInfo(1, "Gregory", "Hospital", "Hospital description"),
            new LocationInfo(1, "Tomas", "OfisFBI", "Ofis FBI description"),
            new LocationInfo(1, "Mark", "PlaneDown", "Down Plane description")
        }));
        listDays.Add(new DayInfo(2, "�������� ����, ����������� � ��� ������.", new List<LocationInfo>()
        {
            new LocationInfo(2, "Gregory", "House", "Hospital description"),
            new LocationInfo(2, "Tomas", "OfisFBI", "Ofis FBI description"),
            new LocationInfo(2, "Derek", "University", "University description")
        }));
        listDays.Add(new DayInfo(3, "�������� ����, ����������� � �������� �������.", new List<LocationInfo>()
        {
            new LocationInfo(3, "Maykl", "BootStation", "Boot station description"),
            new LocationInfo(3, "Tomas", "OfisFBI", "Ofis FBI description"),
            new LocationInfo(3, "Derek", "University", "University description")
        }));
    }

    public void NextDay()
    {
        currentDay++;
        currentDay %= listDays.Count;
        GameManager.Instance.currentDay = $"{currentDay + 1}";
        SetDayButtons();
        btnEnter.interactable = false;
        btnNext.interactable = false;
        mapSounds.PlayClickButton();
    }

    private DayInfo GetDayInfo(int index)
    {
        if (index >= 0 && index < listDays.Count)
        {
            return listDays[index];
        }
        return null;
    }

    public void SelectLocation(int numBtn)
    {
        currentLocationIndex = numBtn;
        SetDayButtons();
        Button btn = null;
        if (numBtn >= 0 && numBtn < arrBtnLocation.Length) btn = arrBtnLocation[numBtn];
        if (btn != null)
        {
            DayInfo di = GetDayInfo(currentDay);
            string title = btn.gameObject.GetComponent<LocationButtonControl>().Title;
            foreach (LocationInfo li in di.ListLocations)
            {
                if (title == li.Title)
                {
                    txtTitle.text = title;
                    txtNameNPC.text = li.NameNPC;
                    txtDescr.text = li.Description;
                    btnNext.interactable = true;
                    btn.gameObject.GetComponent<Image>().color = arButtonColors[0];
                    btnEnter.interactable = true;
                    break;
                }
            }
        }
        mapSounds.PlayClickItem();
    }

    public void EnterButtonClick()
    {
        mapSounds.PlayClickButton();
        if (currentLocationIndex >= 0 && currentLocationIndex < 9)
        {
            ManagerScene.Instance.LoadLocationScene(currentLocationIndex);
        }
    }

    public void LoadBookScene()
    {
        mapSounds.PlayClickButton();
        ManagerScene.Instance.LoadLocationScene(9);
    }
}
