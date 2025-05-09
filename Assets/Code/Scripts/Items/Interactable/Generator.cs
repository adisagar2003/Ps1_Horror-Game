using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject generatorUI;

    public delegate void DisablePlayer();
    public static event DisablePlayer OnDisablePlayer;

    public delegate void EnablePlayer();
    public static event EnablePlayer OnEnablePlayer;

    private PlayerState _playerState;
    private UI_Generator _generatorUI;

    void Start()
    {
        _playerState = FindFirstObjectByType<PlayerState>();
        _generatorUI = GetComponent<UI_Generator>();
    }
    public void Interact()
    {
        // show UI
        _generatorUI.PopulateData();
        generatorUI.SetActive(true);
        OnDisablePlayer?.Invoke();
        CursorControl.ShowCursor();
    }

    public void CloseGeneratorUI()
    {
        generatorUI.SetActive(false);
        OnEnablePlayer?.Invoke();
        CursorControl.HideCursor();
    }

    void Update()
    {
        
    }
}
