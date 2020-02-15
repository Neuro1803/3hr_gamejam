using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TowerBuilder : MonoBehaviour
{

    private int _activeBuilder = 0;
    public List<Mod> Mods = new List<Mod>();

    public Text DMG;
    public Text FireRate;
    public Text Targets;
    public Text Range;

    public Text TimerDisplay;
    private float timer;

    private void UpdateButton(int idx)
    {
        transform.GetChild(idx).GetComponent<Image>().sprite = Mods[_activeBuilder].sprite;
        transform.GetChild(idx).GetComponent<FactorySlot>().myMod = Mods[_activeBuilder];
    }

    public TowerStatistics BuildWholeTower()
    {
        TowerStatistics retVal = new TowerStatistics();
        for(int i = 0; i < transform.childCount; i++)
        {
            Mod source = transform.GetChild(i).GetComponent<FactorySlot>().myMod;
            retVal.damage += source.DmgMod;
            retVal.fireRate += source.ShotsMod;
            retVal.multiTarget += source.MultiMod;
            retVal.range += source.RangeMod;
        }

        retVal.damage += 1;
        retVal.fireRate += 1;
        retVal.multiTarget += 1;
        retVal.range += 1;

        return retVal;
    }

    public void SetActiveBuilder(int id)
    {
        _activeBuilder = id;
    }

    public void UpdateMe(int id)
    {
        UpdateButton(id);
    }

    public void UpdateGui()
    {
        TowerStatistics stats = BuildWholeTower();
          DMG.text = stats.damage.ToString();
          FireRate.text = stats.fireRate.ToString();
          Targets.text = stats.multiTarget.ToString();
          Range.text = stats.range.ToString();
    }

    public void Update()
    {
        UpdateGui();
        timer += Time.deltaTime;
        CalculateTime();
    }

    private void CalculateTime()
    {
        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.RoundToInt(timer % 60);

        TimerDisplay.text = seconds.ToString();
    }


}
