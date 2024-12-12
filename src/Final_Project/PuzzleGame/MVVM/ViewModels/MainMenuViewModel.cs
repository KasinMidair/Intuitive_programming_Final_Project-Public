﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using PuzzleGame.Core;
using PuzzleGame.Core.Helper;
using Prism.Events;
using PuzzleGame.Stores;

namespace PuzzleGame.MVVM.ViewModels
{
    public class MainMenuViewModel : ObservableObject
    {

        private ObservableObject _currentPage;
        public ObservableObject CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    EventAggregator.GetEvent<PubSubEvent<ObservableObject>>().Publish(CurrentPage);
                }
            }
        }

        public RelayCommand<object> StartCommand { get; set; } //command for start button
        public RelayCommand<string> ShowMSGBoxCommand { get; set; }


        public MainMenuViewModel()
        {
            _wndBgr = defaultColornum1;
            StartCommand = new RelayCommand<object>((o) =>
            {
                CurrentPage = new UserEnterNameViewModel();

            });
            ShowMSGBoxCommand = new RelayCommand<string>((o) => { ShowCustomDialog(o); });
        }
        private void ShowCustomDialog(string o)
        {
            CustomDialogResult a = CusDialogService.Instance.ShowDialog(o).Result;
            if (a == CustomDialogResult.OK)
            {
                MessageBox.Show("OKKKKK");

            }
        }
    }
}
