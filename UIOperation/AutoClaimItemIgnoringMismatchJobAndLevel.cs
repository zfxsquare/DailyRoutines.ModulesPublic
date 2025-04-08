﻿using System;
using DailyRoutines.Abstracts;
using Dalamud.Game.Addon.Lifecycle;
using Dalamud.Game.Addon.Lifecycle.AddonArgTypes;

namespace DailyRoutines.Modules;

public unsafe class AutoClaimItemIgnoringMismatchJobAndLevel : DailyModuleBase
{
    public override ModuleInfo Info { get; } = new()
    {
        Title       = GetLoc("AutoClaimItemIgnoringMismatchJobAndLevelTitle"),
        Description = GetLoc("AutoClaimItemIgnoringMismatchJobAndLevelDescription"),
        Category    = ModuleCategories.UIOperation
    };

    public override void Init()
    {
        DService.AddonLifecycle.RegisterListener(AddonEvent.PostSetup, "SelectYesno", OnAddon);
        if (IsAddonAndNodesReady(SelectYesno)) OnAddon(AddonEvent.PostSetup, null);
    }

    private void OnAddon(AddonEvent type, AddonArgs? args)
    {
        if (!IsAddonAndNodesReady(SelectYesno)) return;
        
        ClickSelectYesnoYes
        ([
            LuminaWarpper.GetAddonText(1962), 
            LuminaWarpper.GetAddonText(2436), 
            LuminaWarpper.GetAddonText(11502), 
            LuminaWarpper.GetAddonText(11508)
        ]);
    }

    public override void Uninit() => DService.AddonLifecycle.UnregisterListener(OnAddon);
}
