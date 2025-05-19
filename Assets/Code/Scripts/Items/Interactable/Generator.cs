using System;
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

    private PlayerStateHandle _playerState;
    private GeneratorUI _generatorUI;

    private bool isGeneratorRunning = false;
    [SerializeField] private Light generatorLight;

    [SerializeField] private AudioSource startGeneratorAudio;

    // event: Makes gate button work.
    
    void Start()
    {
        _playerState = FindFirstObjectByType<PlayerStateHandle>();
        _generatorUI = GetComponent<GeneratorUI>();
    }

    private void OnEnable()
    {
        GeneratorUI.OnGeneratorTurned += TurnGeneratorOn;
    }

    private void OnDisable()
    {
        GeneratorUI.OnGeneratorTurned -= TurnGeneratorOn;
    }

    [ContextMenu("Turn Generator On")]
    private void TurnGeneratorOn()
    {
        startGeneratorAudio.Play();
        CloseGeneratorUI();
        isGeneratorRunning = true;
        generatorLight.color = Color.green;
        gameObject.layer = 0; // makes it non interactable
    }

    public void Interact()
    {
        if (isGeneratorRunning) return;
        // show UI
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

    public bool GetIsGeneratorRunning()
    {
        return isGeneratorRunning;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseGeneratorUI();
        }
    }
}
