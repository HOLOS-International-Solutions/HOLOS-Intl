﻿using System;
using H.Core.Enumerations;
using H.Core.Providers.Animals;

namespace H.Avalonia.ViewModels.OptionsViews
{
    public class DefaultManureCompositionDataViewModel : ViewModelBase
    {
        #region Fields

        private DefaultManureCompositionData _dataClassInstance;
        private double _moistureContent;
        private double _nitrogenFraction;
        private double _carbonFraction;
        private double _phosphorusFraction;
        private double _carbonToNitrogenRatio;
        private bool _supressValidationFlag;

        #endregion

        #region Constructors

        /// <summary>
        /// This class is a view model wrapper over <see cref="DefaultManureCompositionData"/> that provides data validation 
        /// </summary>
        /// <param name="dataClassInstance"></param>
        public DefaultManureCompositionDataViewModel(DefaultManureCompositionData dataClassInstance)
        {
            if (dataClassInstance != null)
            {
                _dataClassInstance = dataClassInstance;
            }
            else
            {
                throw (new ArgumentNullException(nameof(dataClassInstance)));
            }
        }

        #endregion

        #region Properties

        public AnimalType AnimalType
        {
            get { return _dataClassInstance.AnimalType; }
        }

        public string ManureStateTypeString
        {
            get { return _dataClassInstance.ManureStateTypeString; }
        }

        public double MoistureContent
        {
            get => _moistureContent;
            set
            {
                if(SetProperty(ref _moistureContent, value))
                {
                    if (ValidateNumericProperty(nameof(MoistureContent), value) && !_supressValidationFlag)
                    {
                        _dataClassInstance.MoistureContent = value;
                    }
                }
            }
        }

        public double NitrogenFraction
        {
            get => _nitrogenFraction;
            set
            {
                if (SetProperty(ref _nitrogenFraction, value))
                {
                    if (ValidateNumericProperty(nameof(NitrogenFraction), value) && !_supressValidationFlag)
                    {
                        _dataClassInstance.NitrogenFraction = value;
                    }
                }
            }
        }

        public double CarbonFraction
        {
            get => _carbonFraction;
            set
            {
                if (SetProperty(ref _carbonFraction, value))
                {
                    if (ValidateNumericProperty(nameof(CarbonFraction), value) && !_supressValidationFlag)
                    {
                        _dataClassInstance.CarbonFraction = value;
                    }
                }
            }
        }

        public double PhosphorusFraction  
        {
            get => _phosphorusFraction;
            set
            {
                if (SetProperty(ref _phosphorusFraction, value))
                {
                    if (ValidateNumericProperty(nameof(PhosphorusFraction), value) && !_supressValidationFlag)
                    {
                        _dataClassInstance.PhosphorusFraction = value;
                    }
                }
            }
        }

        public double CarbonToNitrogenRatio
        {
            get => _carbonToNitrogenRatio;
            set
            {
                if (SetProperty(ref _carbonToNitrogenRatio, value))
                {
                    if (ValidateNumericProperty(nameof(CarbonToNitrogenRatio), value) && !_supressValidationFlag)
                    {
                        _dataClassInstance.CarbonToNitrogenRatio = value;
                    }
                }
            }
        }

        #endregion

        #region Public Methods

        public void SetSuppressValidationFlag(bool flag)
        {
            _supressValidationFlag = flag;
        }

        #endregion

        #region Private Methods

        private bool ValidateNumericProperty(string propertyName, double property)
        {
            RemoveError(propertyName);

            if (property < 0.0)
            {
                AddError(propertyName, H.Core.Properties.Resources.ErrorMustBeGreaterThan0);
                return false;
            }

            return true;
        }

        #endregion
    }
}
