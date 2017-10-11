﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamplate.ViewModels;

namespace Xamplate.Services
{
    public class Navigator : INavigator
    {

        private readonly Lazy<INavigation> _navigation;
        private readonly IViewFactory _viewFactory;

        public Navigator(Lazy<INavigation> navigation, IViewFactory viewFactory)
        {
            _navigation = navigation;
            _viewFactory = viewFactory;
        }

        private INavigation Navigation => _navigation.Value;

        public async Task PopAsync()
        {
            await Navigation.PopAsync();
        }

        public async Task PopToRootAsync()
        {
            await Navigation.PopToRootAsync();
        }

        public async Task PushAsync<TViewModel>() where TViewModel : class, IViewModelBase
        {
            var view = _viewFactory.Resolve<TViewModel>();
            await Navigation.PushAsync(view);
        }

        public async Task PushModalAsync<TViewModel>() where TViewModel : class, IViewModelBase
        {
            var view = _viewFactory.Resolve<TViewModel>();
            await Navigation.PushModalAsync(view);
        }
    }
}