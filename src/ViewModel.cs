﻿
using System.Collections.Generic;
using System.Windows;

namespace EverythingNET
{
    class ViewModel : ViewModelBase
    {
        TypeAssistant TypeAssistant;

        public ViewModel()
        {
            TypeAssistant = new TypeAssistant();
            TypeAssistant.Idled += TypeAssistant_Idled;
        }

        private List<Item> ItemsValue;

        public List<Item> Items {
            get => ItemsValue;
            set {
                ItemsValue = value;
                OnPropertyChanged();
            }
        }

        string SearchTextValue;

        public string SearchText {
            get => SearchTextValue;
            set {
                SearchTextValue = value;
                TypeAssistant.TextChanged(value);
            }
        }

        void TypeAssistant_Idled(string text)
        {
            Update();
        }

        public void Update()
        {
            List<Item> items = Model.GetItems(SearchText);
            Application.Current.Dispatcher.Invoke(() => Items = items);
        }
    }
}
