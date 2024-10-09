using H.Avalonia.Views;
using H.Core.Enumerations;
using H.Core.Services;
using H.Infrastructure;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;
using H.Core.Services.Provinces;

namespace H.Avalonia.ViewModels.SupportingViews.MeasurementProvince
{
    public class MeasurementProvinceViewModel : BindableBase
    {
        #region Fields

        private MeasurementSystemType _selectedMeasurementSystem;
        private object _selectedProvince;
        private readonly IRegionManager _regionManager;
        private readonly IProvinces _provincesService;
        private readonly ICountrySettings _countrySettings;

        #endregion

        #region Constructors

        public MeasurementProvinceViewModel(IRegionManager regionManager, IProvinces provincesService, ICountrySettings countrySettings)
        {
            _regionManager = regionManager;
            _provincesService = provincesService;
            _countrySettings = countrySettings;

            MeasurementSystemCollection = new ObservableCollection<MeasurementSystemType>(EnumHelper.GetValues<MeasurementSystemType>());
            ProvinceCollection = new ObservableCollection<object>(_provincesService.GetProvinces());

            // Set default selected province to the first one or a default value
            _selectedProvince = ProvinceCollection.FirstOrDefault() ?? new object();
            SelectedProvince = _selectedProvince;

            NavigateCommand = new DelegateCommand(OnNavigate);
        }

        #endregion

        #region Properties

        public ObservableCollection<MeasurementSystemType> MeasurementSystemCollection { get; set; }
        public ObservableCollection<object> ProvinceCollection { get; set; }

        public MeasurementSystemType SelectedMeasurementSystem
        {
            get { return _selectedMeasurementSystem; }
            set { SetProperty(ref _selectedMeasurementSystem, value); }
        }

        public object SelectedProvince
        {
            get { return _selectedProvince; }
            set { SetProperty(ref _selectedProvince, value); }
        }

        public ICommand NavigateCommand { get; }

        #endregion

        #region Methods

        private void OnNavigate()
        {
            // Navigate to next view based on country version
            if (_countrySettings.Version == CountryVersion.Canada)
            {
                _regionManager.RequestNavigate(UiRegions.ContentRegion, nameof(SoilDataView));
            }
            else
            {
                _regionManager.RequestNavigate(UiRegions.ContentRegion, nameof(ClimateDataView));
            }
        }

        #endregion
    }
}