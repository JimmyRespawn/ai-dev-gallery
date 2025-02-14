// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AIDevGallery.Models;
using AIDevGallery.Samples;
using AIDevGallery.Utils;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AIDevGallery.Pages;

internal sealed partial class ScenarioOverviewPage : Page
{
    private ObservableCollection<ScenarioCategory> allScenarioCategories;
    private ObservableCollection<MostRecentlyUsedItem> mostRecentlyUsedCategories;

    public ScenarioOverviewPage()
    {
        this.InitializeComponent();
        allScenarioCategories = new ObservableCollection<ScenarioCategory>();
        mostRecentlyUsedCategories = new ObservableCollection<MostRecentlyUsedItem>();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        foreach (var category in ScenarioCategoryHelpers.AllScenarioCategories)
        {
            allScenarioCategories.Add(category);
        }

        /* List<Scenario> recentScenarios = new List<Scenario>();

        foreach (var mru in App.AppData.MostRecentlyUsedItems)
        {
            if (mru.Type == Utils.MostRecentlyUsedItemType.Scenario)
            {
                recentScenarios.Add(App.FindScenarioById(mru.ItemId));
            }
        }

        ScenarioCategory recentCategory = new ScenarioCategory
        {
            Name = "Recent",
            Description = "Recently used scenarios",
            Icon = "\uE81C",
            Scenarios = recentScenarios
        };

        if (recentScenarios.Count > 0)
        {
            allScenarioCategories.Insert(0, recentCategory);
        } */
    }

    private void ScenarioItemsView_ItemInvoked(ItemsView sender, ItemsViewItemInvokedEventArgs args)
    {
        if (args.InvokedItem is Scenario scenario)
        {
            App.MainWindow.NavigateToPage(scenario);
        }
    }
}