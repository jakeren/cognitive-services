﻿using Caliburn.Micro;
using RealTimeFaceInsights.Interfaces;
using RealTimeFaceInsights.Services;
using RealTimeFaceInsights.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace RealTimeFaceInsights
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container;
        
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container = new SimpleContainer();

            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.Singleton<IComputerVisionService, ComputerVisionService>();
            _container.Singleton<IEmotionService, EmotionService>();
            _container.Singleton<IFaceService, FaceService>();
            _container.Singleton<IOpenCVService, OpenCVService>();
            _container.Singleton<IVideoFrameAnalyzerService, VideoFrameAnalyzerService>();
            _container.Singleton<IVisualizationService, VisualizationService>();

            _container.PerRequest<ShellViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
