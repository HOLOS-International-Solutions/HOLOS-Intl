using ExCSS;
using H.Core.Enumerations;
using H.Core.Properties;
using H.Infrastructure;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using H.Avalonia.Views;
using H.Core.Services;
using Prism.Commands;
using H.Avalonia.Views.SupportingViews.MeasurementProvince;

namespace H.Avalonia.ViewModels.SupportingViews.Disclaimer
{
    public class DisclaimerViewModel : ViewModelBase
    {
        #region Fields

        private Languages _selectedLanguage;

        private bool _showLanguageBox;
        private string _aboutHolosString;
        private string _toBeKeptInformedString;
        private string _disclaimerRtfString;
        private string _versionString;
        private string _disclaimerWordString;

        private DelegateCommand<object> _okCommand;

        private ICountrySettings _countrySettings;

        #endregion

        #region Constructors

        public DisclaimerViewModel()
        {
            this.Construct();
        }

        public DisclaimerViewModel(IRegionManager regionManager,
                                   IEventAggregator eventAggregator,
                                   Storage storage,
                                   ICountrySettings countrySettings) : base(regionManager, eventAggregator, storage)
        {
            if (countrySettings != null)
            {
                _countrySettings = countrySettings; 
            }
            else
            {
                throw new ArgumentNullException(nameof(countrySettings));
            }

            LanguageCollection = new ObservableCollection<Languages>(EnumHelper.GetValues<Languages>());
            this.Construct();
        }

        #endregion

        #region Properties
        public ObservableCollection<Languages> LanguageCollection { get; set; }

        public Languages SelectedLanguage
        {
            get { return _selectedLanguage; }
            set { SetProperty(ref _selectedLanguage, value, OnSelectedLanguageChanged); }
        }

        public string AboutHolosString
        {
            get { return _aboutHolosString; }
            set { SetProperty(ref _aboutHolosString, value); }
        }

        public string ToBeKeptInformedString
        {
            get { return _toBeKeptInformedString; }
            set { SetProperty(ref _toBeKeptInformedString, value); }
        }

        public string DisclaimerRtfString
        {
            get { return _disclaimerRtfString; }
            set { SetProperty(ref _disclaimerRtfString, value); }
        }
        public string DisclaimerWordString
        {
            get { return _disclaimerWordString; }
            set { SetProperty(ref _disclaimerWordString, value); }
        }

        public string VersionString
        {
            get { return _versionString; }
            set { _versionString = value; }
        }
        public bool ShowLanguageBox
        {
            get { return _showLanguageBox; }
            set { SetProperty(ref _showLanguageBox, value); }
        }

        public DelegateCommand<object> OkCommand
        {
            get => _okCommand;
            set => SetProperty(ref _okCommand, value);
        }

        #endregion

        #region Public Methods

        public new void Construct()
        {
            this.SetHolosLanguageToSystemLanguage();
            this.UpdateDisplayBasedOnLanguage();
            this.VersionString = GuiConstants.GetVersionString();

            this.OkCommand = new DelegateCommand<object>(OnOkExecute, OkCanExecute);
        }

        #endregion

        #region Private Methods

        private void UpdateDisplayBasedOnLanguage()
        {
            if (this.SelectedLanguage == Languages.English)
            {
                this.AboutHolosString = "HOLOS-IE - a tool to estimate and reduce greenhouse gas emissions from farms";
                this.ToBeKeptInformedString = "To be kept informed about  future versions, please send your contact information (including email address) to ibrahim.khalil1@ucd.ie";
                this.DisclaimerRtfString = Resources.Disclaimer_English_TXT;

                this.DisclaimerWordString = "Disclaimer";
                Settings.Default.DisplayLanguage = Languages.English.GetDescription();
            }
            else
            {
                this.AboutHolosString = "Holos - outil d'évaluation et de réduction des émissions de gaz à effet de serre des fermes agricoles";
                this.ToBeKeptInformedString = "Pour être informé de la publication des prochaines versions du logiciel, faites parvenir vos coordonnées (y compris votre adresse électronique) à ibrahim.khalil1@ucd.ie";
                this.DisclaimerRtfString = Resources.Disclaimer_French_TXT;
                this.DisclaimerWordString = "Avis de non-responsabilité";

                Settings.Default.DisplayLanguage = Languages.French.GetDescription();
            }
        }

        private void SetHolosLanguageToSystemLanguage()
        {
            const string usEnglish = "en-US";
            var culture = Thread.CurrentThread.CurrentCulture;

            //some computers might have their region set to united states english best to keep their gui in english
            //if (culture.Name == Infrastructure.InfrastructureConstants.EnglishCultureInfo.Name || culture.Name == usEnglish)
            //{
            //    this.SelectedLanguage = Core.Enumerations.Languages.English;
            //}
            //else
            //{
            //    this.SelectedLanguage = Core.Enumerations.Languages.French;
            //}
            // Currently, we are supporting only English
            this.SelectedLanguage = Languages.English;
        }

        #endregion

        #region Event Handlers

        private void OnSelectedLanguageChanged()
        {
            this.UpdateDisplayBasedOnLanguage();
        }

        private void OnOkExecute(object obj)
        {
            base.RegionManager.RequestNavigate(UiRegions.ContentRegion, nameof(MeasurementProvinceView));         
        }

        private bool OkCanExecute(object arg)
        {
            return true;
        }

        #endregion
    }
}
