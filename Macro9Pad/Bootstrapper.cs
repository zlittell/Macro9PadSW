using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using Macro9Pad.Models;
using Macro9Pad.ViewModels;

namespace Macro9Pad
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container;

        public Bootstrapper()
        {
            this.Initialize();
        }

        protected override void Configure()
        {
            this.container = new SimpleContainer();

            this.container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<DeviceModel>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<EventHandler>();

            // Instantiate any singletons ahead of time
            this.container.GetInstance<DeviceModel>();
            this.container.GetInstance<EventHandler>();


            // Register all viewmodels with container
            this.GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel", StringComparison.InvariantCulture))
                .ToList()
                .ForEach(viewModelType => this.container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            this.DisplayRootViewFor<MainViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return this.container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return this.container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            this.container.BuildUp(instance);
        }
    }
}
