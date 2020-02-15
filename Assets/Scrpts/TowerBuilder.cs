using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerBuilder : MonoBehaviour
{

    private int _activeBuilder = 0;
    private List<Mod> Mods = new List<Mod>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateButton(int idx)
    {
        transform.GetChild(idx).GetComponent<Button>().image = Mods[_activeBuilder].Image;
        transform.GetChild(idx).GetComponent<FactorySlot>().myMod = Mods[_activeBuilder];
    }


    public void BuildWholeTower()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<FactorySlot>();
        }
    }

    public void SetActiveBuilder(int id)
    {
        _activeBuilder = id;
    }

    public void UpdateMe(int id)
    {
        UpdateButton(id);
    }
}
