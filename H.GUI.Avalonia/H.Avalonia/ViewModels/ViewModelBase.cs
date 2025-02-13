﻿using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls.Notifications;
using H.Core.Services.StorageService;
using Prism.Events;

namespace H.Avalonia.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        #region Fields

        protected bool IsInitialized;

        private Storage _storage; 
        private IEventAggregator _eventAggregator;
        private IRegionManager _regionManager;
        private IStorageService _storageService;

        #endregion

        #region Constructors

        protected ViewModelBase()
        {
        }

        protected ViewModelBase(Storage storage)
        {
            if (storage != null)
            {
                this.Storage = storage;
            }
            else
            {
                throw new ArgumentNullException(nameof(storage));
            }
        }

        protected ViewModelBase(IEventAggregator eventAggregator)
        {
            if (eventAggregator != null)
            {
                this.EventAggregator = eventAggregator;
            }
            else
            {
                throw new ArgumentNullException(nameof(eventAggregator));
            }
        }

        protected ViewModelBase(IRegionManager regionManager)
        {
            if (regionManager != null)
            {
                RegionManager = regionManager;
            }
            else
            {
                throw new ArgumentNullException(nameof(regionManager));
            }
        }

        protected ViewModelBase(IRegionManager regionManager, IStorageService storageService)
        {
            if (storageService != null)
            {
                this.StorageService = storageService;
            }
            else
            {
                throw new ArgumentNullException(nameof(storageService));
            }

            if (regionManager != null)
            {
                RegionManager = regionManager;
            }
            else
            {
                throw new ArgumentNullException(nameof(regionManager));
            }
        }

        protected ViewModelBase(IRegionManager regionManager, Storage storage) : this(regionManager)
        {
            if (storage != null)
            {
                Storage = storage;
            }
            else
            {
                throw new ArgumentNullException(nameof(storage));
            }
        }

        protected ViewModelBase(IRegionManager regionManager, IEventAggregator eventAggregator) : this(regionManager)
        {
            if(eventAggregator != null)
            {
                this.EventAggregator = eventAggregator;
            }
            else
            {
                throw new ArgumentNullException(nameof(eventAggregator));
            }
        }

        protected ViewModelBase(IRegionManager regionManager, IEventAggregator eventAggregator, Storage storage) : this(regionManager, storage)
        {
            if (eventAggregator != null)
            {
                this.EventAggregator = eventAggregator;
            }
            else
            {
                throw new ArgumentNullException(nameof(eventAggregator));
            }
        }

        #endregion

        #region Properties
        
        /// <summary>
        /// A storage file that contains various data items that are shored between viewmodels are passed around the system. This storage
        /// item is instantiated using Prism and through Dependency Injection, is passed within the system.
        /// </summary>
        public Storage Storage
        {
            get => _storage;
            set => SetProperty(ref _storage, value);
        }

        /// <summary>
        /// The notification manager that handles displaying notifications on the page.
        /// </summary>
        public WindowNotificationManager NotificationManager { get; set; }

        protected IRegionManager RegionManager
        {
            get => _regionManager;
            set => SetProperty(ref _regionManager, value);
        }

        protected IEventAggregator EventAggregator 
        {
            get => _eventAggregator;
            set { SetProperty(ref _eventAggregator, value); } 
        }

        public IStorageService StorageService
        {
            get => _storageService;
            set => SetProperty(ref _storageService, value);
        }

        #endregion

        #region Public Methods

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        /// <summary>Navigation validation checker.</summary>
        /// <remarks>Override for Prism 7.2's IsNavigationTarget.</remarks>
        /// <param name="navigationContext">The navigation context.</param>
        /// <returns><see langword="true"/> if this instance accepts the navigation request; otherwise, <see langword="false"/>.</returns>
        public virtual bool OnNavigatingTo(NavigationContext navigationContext)
        {
            return true;
        } 

        #endregion
    }
}
