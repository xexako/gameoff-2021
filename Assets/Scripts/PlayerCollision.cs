﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public UIManager uiman;
    public void Explode()
    {
        uiman.ToggleGameOverPanel(false, "DEFEAT");
    }
}
