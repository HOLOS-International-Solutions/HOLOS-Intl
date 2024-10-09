using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Prism.Regions;
using H.Avalonia.ViewModels.SupportingViews.MeasurementProvince;
using H.Core.Services.Provinces;
using H.Core.Services;

namespace H.Avalonia.Views.SupportingViews.MeasurementProvince
{
    public partial class MeasurementProvinceView : UserControl
    {
        public MeasurementProvinceView(IRegionManager regionManager, IProvinces provincesService, ICountrySettings countrySettings)
        {
            InitializeComponent();
            DataContext = new MeasurementProvinceViewModel(regionManager, provincesService, countrySettings);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}