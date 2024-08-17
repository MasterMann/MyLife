﻿using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MyLife.App.Shared.UI.Tabs.ViewModels.Content;
using MyLife.App.Shared.UI.ViewModels.Components.Buttons;


namespace MyLife.App.Plugins.Content.Todo.ViewModels;


public partial class TodoTabContentViewModel : TabContentViewModel
{
	[ObservableProperty]
	FloatingActionButtonViewModel _actions;

	[ObservableProperty]
	ObservableCollection<TodoItemViewModel> _items = [];

	[ObservableProperty]
	string selectedListId = string.Empty;

	string _itemTextBeforeEditing = string.Empty;
	string _itemInEdit = string.Empty;

	public TodoTabContentViewModel()
	{
		this.Actions = new()
		{
			Id = "fab-actions",
			InitialIcon = "Pencil",
			Actions =
			[
				new()
				{
					Id = "fab-actions-add-entry",
					IconId = "Plus",
					Label = "New entry",
					IsEnabled = true,
					Command = this.AddNewItemCommand
				},
				new()
				{
					Id = "fab-actions-add-list",
					IconId = "PlaylistPlus",
					Label = "New list",
					IsEnabled = true
				},
				new()
				{
					Id = "fab-actions-empty-list",
					IconId = "Delete",
					Label = "Empty list",
					IsEnabled = true,
					Command = this.ClearItemListCommand
				},
				new()
				{
					Id = "fab-actions-delete-list",
					IconId = "DeleteForever",
					Label = "Delete list",
					IsEnabled = true
				}
			]
		};
	}

	[RelayCommand]
	public void AddNewItem(object? param)
	{
		var itemID = Guid.NewGuid().ToString();

		this.Items.Add(new TodoItemViewModel
		{
			Id = itemID
		});

		this.SwitchItemToEdit(itemID);
	}

	// TODO: Show confirmation dialog
	[RelayCommand]
	public void ClearItemList(object? param) => this.Items.Clear();

	[RelayCommand]
	public void SwitchItemToEdit(string itemID)
	{
		if (this._itemInEdit != string.Empty) this.CancelItemEditing(this._itemInEdit);

		var foundItem = this.Items.FirstOrDefault(item => item.Id == itemID);
		if (foundItem != null)
		{
			this._itemTextBeforeEditing = foundItem.Text;
			this._itemInEdit = foundItem.Id;

			foundItem.IsEditModeEnabled = true;
		}
	}

	[RelayCommand]
	public void SwitchItemToView(string itemID)
	{
		var foundItem = this.Items.FirstOrDefault(item => item.Id == itemID);
		if (foundItem != null)
		{
			foundItem.IsEditModeEnabled = false;

			this._itemTextBeforeEditing = string.Empty;
			this._itemInEdit = string.Empty;
		}
	}

	[RelayCommand]
	public void CancelItemEditing(string itemID)
	{
		var foundItem = this.Items.FirstOrDefault(item => item.Id == itemID);
		if (foundItem != null)
		{
			foundItem.Text = this._itemTextBeforeEditing;
			foundItem.IsEditModeEnabled = false;

			this._itemTextBeforeEditing = string.Empty;
			this._itemInEdit = string.Empty;
		}
	}

	// TODO: Show confirmation dialog
	[RelayCommand]	
	public void DeleteItem(string itemID)
	{
		var foundItem = this.Items.FirstOrDefault(item => item.Id == itemID);
		if (foundItem != null)
		{
			this.Items.Remove(foundItem);
		}
	}
}
