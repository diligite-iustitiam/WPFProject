﻿
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WPFProject.Infrastructure.Commands;
using WPFProject.Models;
using WPFProject.ViewModels.Base;

namespace WPFProject.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region ChangeTabIndexCommand

        private int _SelectedPageIndex = 0;

        public int SelectedPageIndex { get => _SelectedPageIndex; set => Set(ref _SelectedPageIndex, value); }

       

        public ICommand ChangeTabIndexCommand { get; }

        private bool CanChangeTabIndexCommandExecute(object p) => _SelectedPageIndex >= 0;

        private void OnChangeTabIndexCommandExecuted(object p)
        {
            if (p is null) return;
            SelectedPageIndex += Convert.ToInt32(p);
        }
        #endregion
        #region TestDataPoint

        private IEnumerable<DataPoint> _TestDataPoints;

        public IEnumerable<DataPoint> TestDataPoints { get => _TestDataPoints;
            set => Set(ref _TestDataPoints, value);
        }

        #endregion
        #region Title
        private string _Title = "WPFProject";
        /// <summary>Window title</summary>
        public string Title
        {
            get { return _Title; }
            set => Set(ref _Title, value);
        }

        private string _Status ="Ready";
        /// <summary>Program status</summary>
        public string Status
        {
            get { return _Status; }
            set => Set(ref _Status, value);
        }
        #endregion
        #region Commands
        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Commands


            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecuted, CanChangeTabIndexCommandExecute);

            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1)); 
            for(var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new DataPoint
                {
                    XValue = x,
                    YValue = y
                });
            }
            TestDataPoints = data_points;
        }
    }
}
