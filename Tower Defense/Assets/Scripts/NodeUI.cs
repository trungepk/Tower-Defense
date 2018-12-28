﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour {

    [SerializeField] GameObject ui;
    private Node target;

    public void SetTarget(Node target)
    {
        this.target = target;
        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
