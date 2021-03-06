﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamplate.Interfaces;

namespace Xamplate.ViewModels
{
	public abstract class BaseViewModel : IViewModelBase
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
		}
	}
}
