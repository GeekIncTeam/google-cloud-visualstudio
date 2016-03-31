﻿// Copyright 2015 Google Inc. All Rights Reserved.
// Licensed under the Apache License Version 2.0.

using GoogleCloudExtension.CloudExplorer;
using GoogleCloudExtension.DataSources.Models;
using GoogleCloudExtension.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace GoogleCloudExtension.CloudExplorerSources.Gce
{
    public class ZoneViewModel : TreeHierarchy
    {
        private const string IconResourcePath = "CloudExplorerSources/AppEngine/Resources/ic_view_module.png";
        private static readonly Lazy<ImageSource> s_zoneIcon = new Lazy<ImageSource>(() => ResourceUtils.LoadResource(IconResourcePath));

        public ZoneViewModel(string key, IEnumerable<GceInstance> instances)
        {
            Content = key;
            Icon = s_zoneIcon.Value;

            var viewModels = instances.Select(x => new GceInstanceViewModel(x));
            foreach (var viewModel in viewModels)
            {
                Children.Add(viewModel);
            }
        }
    }
}