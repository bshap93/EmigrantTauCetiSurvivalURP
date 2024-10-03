﻿using Environment.Interactables.CraftingStations.Scripts.Commands;
using Environment.Interactables.Openable.Scripts;
using Polyperfect.Crafting.Integration.UGUI;
using UnityEngine;

namespace Environment.Interactables.CraftingStations.Scripts
{
    public class OpenableCraftingTable : OpenableObject
    {
        public UGUICrafter crafter;
        void Start()
        {
            CurrentState = OpenableState.Closed;
            OpenCommand = new OpenCraftingTableCommand(this);
            CloseCommand = new CloseCraftingTableCommand(this);
            openingMechanism = OpeningMechanism.UseCraftingStation;
        }

        void Update()
        {
            // Opening and Closing are not really used in this case
            // To keep consistency with the other Openable objects, 
            // Move to open from opening or close from closing
            if (CurrentState == OpenableState.Opening) CurrentState = OpenableState.Open;

            if (CurrentState == OpenableState.Closing) CurrentState = OpenableState.Closed;
        }
        public override void SetState(OpenableState newState)
        {
            CurrentState = newState;
        }
        public override void MoveObject()
        {
            // Object does not move from use
        }
        public override void Open()
        {
            Debug.Log("Player is using crafting station");
            OpenCommand.Execute();
        }
        public override void Close()
        {
            Debug.Log("Player is done using crafting station");
            CloseCommand.Execute();
        }
    }
}
