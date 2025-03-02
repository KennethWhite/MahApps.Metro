﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Tests.Views
{
    public partial class AnimatedTabControlWindow : TestWindow
    {
        public AnimatedTabControlWindow()
        {
            this.DataContext = this;
            this.InitializeComponent();
        }

        public TestViewModel Data { get; set; } = new TestViewModel();
    }

    public class TestViewModel
    {
        public ObservableCollection<IViewModel> TestViewModels { get; set; } = new ObservableCollection<IViewModel>(new IViewModel[]
                                                                                                                    {
                                                                                                                        new FirstViewModel(),
                                                                                                                        new SecondViewModel()
                                                                                                                    });
    }

    public class TabControlContentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FirstTemplate { get; set; }

        public DataTemplate SecondTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is FirstViewModel)
            {
                return this.FirstTemplate;
            }
            else if (item is SecondViewModel)
            {
                return this.SecondTemplate;
            }
            else
            {
                return base.SelectTemplate(item, container);
            }
        }
    }

    public interface IViewModel
    {
        string Name { get; set; }
    }

    public class FirstViewModel : IViewModel
    {
        public string Name { get; set; } = "First";
    }

    public class SecondViewModel : IViewModel
    {
        public string Name { get; set; } = "Second";
    }
}