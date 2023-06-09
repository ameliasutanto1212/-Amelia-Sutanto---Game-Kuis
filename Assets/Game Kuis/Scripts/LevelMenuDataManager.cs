using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField]
    private UI_LevelPackList _levelPackList = null;

    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private TextMeshProUGUI _tempatKoin = null;

    [Space, SerializeField]
    private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    // Start is called before the first frame update
    void Start()
    {
        if (!_playerProgress.MuatProgres())
        {
            _playerProgress.SimpanProgres();
        }

        _levelPackList.LoadLevelPack(_levelPacks, _playerProgress.progresData);

        _tempatKoin.text = $"{_playerProgress.progresData.koin}";
        AudioManager.instance.PlayBGM(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
