﻿using H.Core.Models.LandManagement.Fields;

namespace H.Core.Factories;

public interface IFieldComponentDtoFactory
{
    IFieldComponentDto Create();
    
    IFieldComponentDto CreateFieldDto(IFieldComponentDto template);
}