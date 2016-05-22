﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

namespace NWebsec.AspNetCore.Core.HttpHeaders.Configuration
{
    public interface ISimpleBooleanConfiguration
    {
        bool Enabled { get; set; }
    }
}