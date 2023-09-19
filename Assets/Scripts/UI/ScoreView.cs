﻿using TMPro;

using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Set(int score)
    {
        _text.text = $"Счёт: {score}";
    }
}