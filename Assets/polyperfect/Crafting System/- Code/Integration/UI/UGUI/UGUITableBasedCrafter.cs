﻿using System;
using System.Collections.Generic;
using System.Linq;
using Polyperfect.Common;
using Polyperfect.Crafting.Framework;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace Polyperfect.Crafting.Integration.UGUI
{
    [RequireComponent(typeof(Crafter))]
    public class UGUITableBasedCrafter : ItemUserBase
    {
        public override string __Usage => "For crafting using tables.";
        
        //[SerializeField] BaseItemStackInventory StartingInventory;
        [SerializeField] List<RecipeCategoryObject> CreatedCategories;
        [SerializeField] ChildConstructor CreationConstructor;
        [SerializeField] ChildConstructor RecipeConstructor;
        [SerializeField] GameObject TableSlotParent;
        Crafter crafter;
        SlottedInventory<ISlot<Quantity, ItemStack>> outputSlots;
        SlottedInventory<ISlot<Quantity, ItemStack>> tableGhostSlots;
        SlottedInventory<ISlot<Quantity, ItemStack>> tableRealSlots;

        void Awake()
        {
            crafter = GetComponent<Crafter>();
            
            outputSlots = new SlottedInventory<ISlot<Quantity, ItemStack>>();
            crafter.SetCraftingMethod(new MatchingPositionSatisfier<ItemStack>(new QuantityAndIDSatisfier<ItemStack>(), int.MaxValue), (inv,items) =>
            {
                using (var sourceIterator = inv.Slots.GetEnumerator())
                using (var requirementsIterator = items.GetEnumerator())
                    while (requirementsIterator.MoveNext() | sourceIterator.MoveNext())
                    {
                        var currentSource = sourceIterator.Current;
                        var currentRequirement = requirementsIterator.Current;
                        var requiredAmount = currentRequirement.Value;
                        var extracted = currentSource.ExtractAmount(requiredAmount);
                        Assert.AreEqual(extracted.ID,currentRequirement.ID);
                        Assert.AreEqual((int)extracted.Value,requiredAmount);
                    }
            });
        }

        protected void Start()
        {
            
            crafter.OnSourceUpdate.AddListener(HandleSourceUpdate);
            crafter.OnRecipeChange.AddListener(HandleRecipeChange);
            tableGhostSlots = new SlottedInventory<ISlot<Quantity, ItemStack>>();
            tableRealSlots = new SlottedInventory<ISlot<Quantity, ItemStack>>();
            foreach (var item in TableSlotParent.GetComponentsInChildren<DualSlot>())
            {
                tableGhostSlots.AddSlot(item.GhostSlot);
                item.RealSlot.Changed += HandleSourceUpdate;
                tableRealSlots.AddSlot(item.RealSlot);
            }
            crafter.Source = tableRealSlots;


            RecipeConstructor.Construct(CreatedCategories.SelectMany(c=>World.CategoryMembers(c.ID).Distinct()), (g,r) =>
            {
                var itemStack = new ItemStack(World.GetRecipeOutputs(r).FirstOrDefault().ID,1);
                g.GetComponentInChildren<ItemSlotComponent>().InsertCompletely(itemStack);
                
                var evt = new EventTrigger.TriggerEvent();
                evt.AddListener(e=> OnRecipeSelected(r));
                g.AddOrGetComponent<EventTrigger>().triggers.Add(new EventTrigger.Entry(){callback = evt, eventID =  EventTriggerType.PointerClick});
            });
        }

        bool lockRecipe = false;  //recipe locking is to keep the recipe from being updated immediately when the items required for crafting are extracted for the crafting operation
        void HandleRecipeChange()
        {
            if (!outputSlots.SlotList.All(s => s.Peek().IsDefault()))
                return;
            
            CreationConstructor.ClearConstructed();
            outputSlots.ClearSlots();
            if (crafter.Recipe != null)
            {
                CreationConstructor.Construct(crafter.Recipe.Output, (g, s) =>
                {
                    var onDemandSlot = g.GetComponent<DualSlot>();
                    onDemandSlot.GhostSlot.InsertCompletely(s);
                    onDemandSlot.RealSlot.OnPreClick += () =>
                    {
                        lockRecipe = true;
                        if (!onDemandSlot.RealSlot.Peek().IsDefault()||!UGUIItemTransfer.Instance.Slot.Peek().IsDefault())
                            return;
                        crafter.CraftAmount(1);
                    };
                    onDemandSlot.RealSlot.OnPostClick += () =>
                    {
                        lockRecipe = false;
                    };
                    outputSlots.AddSlot(onDemandSlot.RealSlot);
                });
                crafter.Destination = outputSlots;
            }
        }
        void HandleSourceUpdate()
        {
            if (lockRecipe)
                return;
            
            crafter.Recipe = AutoSelectRecipe();
        }

        SimpleRecipe AutoSelectRecipe()
        {
            foreach (var createdCategory in CreatedCategories)
            {
                foreach (var recipeID in World.CategoryMembers(createdCategory))
                {
                    var inputs = World.GetRecipeInputs(recipeID);
                    if (crafter.GetMaxCraftAmount(inputs) > 0)
                    {
                        var outputs = World.GetRecipeOutputs(recipeID);
                        return new SimpleRecipe(inputs, outputs);
                    }
                }
            }

            return null;
        }

        void OnRecipeSelected(RuntimeID recipeID)
        {
            tableGhostSlots.ExtractAll();

            using (var slotEnumerator = tableGhostSlots.Slots.GetEnumerator())
            using (var ingredientEnumerator = World.GetRecipeInputs(recipeID).GetEnumerator())
                while (ingredientEnumerator.MoveNext() && slotEnumerator.MoveNext())
                    slotEnumerator.Current.InsertCompletely(ingredientEnumerator.Current);
        }
    }
}