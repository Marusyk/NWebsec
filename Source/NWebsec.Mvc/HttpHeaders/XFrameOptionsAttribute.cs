﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;
using System.Web.Mvc;
using NWebsec.Core.HttpHeaders.Configuration;
using NWebsec.HttpHeaders;
using NWebsec.Mvc.Helpers;
using NWebsec.Mvc.HttpHeaders.Internals;

namespace NWebsec.Mvc.HttpHeaders
{
    /// <summary>
    /// Specifies whether the X-Frame-Options security header should be set in the HTTP response.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class XFrameOptionsAttribute : HttpHeaderAttributeBase
    {
        private readonly IXFrameOptionsConfiguration _config;
        private readonly HeaderConfigurationOverrideHelper _configurationOverrideHelper;
        private readonly HeaderOverrideHelper _headerOverrideHelper;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="XFrameOptionsAttribute"/> class
        /// </summary>
        public XFrameOptionsAttribute()
        {
            _config = new XFrameOptionsConfiguration { Policy = XFrameOptionsPolicy.Deny };
            _configurationOverrideHelper = new HeaderConfigurationOverrideHelper();
            _headerOverrideHelper = new HeaderOverrideHelper();
        }

        /// <summary>
        /// Gets or sets whether the X-Frame-Options security header should be set in the HTTP response.
        /// Possible values are: Disabled, Deny, SameOrigin. The default is Deny.
        /// </summary>
        public XFrameOptionsPolicy Policy { get { return _config.Policy; } set { _config.Policy = value; } }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _configurationOverrideHelper.SetXFrameoptionsOverride(filterContext.HttpContext, _config);
            base.OnActionExecuting(filterContext);
        }

        public override void SetHttpHeadersOnActionExecuted(ActionExecutedContext filterContext)
        {
            _headerOverrideHelper.SetXFrameoptionsHeader(filterContext.HttpContext);
        }
    }
}
