// <copyright file="Bootstrapper.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using Macro9Pad.Device;
using Macro9Pad.Device.Models;
using Macro9Pad.ViewModels;

namespace Macro9Pad
{
  /// <summary>Caliburn bootstrapper clase.</summary>
  public class Bootstrapper : BootstrapperBase
  {
    private SimpleContainer container;

    /// <summary>
    /// Initializes a new instance of the <see cref="Bootstrapper"/> class.
    /// </summary>
    public Bootstrapper()
    {
      this.Initialize();
    }

    /// <inheritdoc/>
    protected override void Configure()
    {
      this.container = new SimpleContainer();

      this.container
          .Singleton<IWindowManager, WindowManager>()
          .Singleton<DeviceModel>()
          .Singleton<IEventAggregator, EventAggregator>()
          .Singleton<DeviceEventProcessor>()
          .Singleton<ConnectionInfo>()
          .Singleton<DeviceConnector>();  // MUST ALWAYS BE LAST

      // Instantiate any singletons ahead of time
      this.container.GetInstance<DeviceModel>();
      this.container.GetInstance<DeviceEventProcessor>();
      this.container.GetInstance<ConnectionInfo>();
      this.container.GetInstance<DeviceConnector>();  // MUST ALWAYS BE LAST
      
      // Register all viewmodels with container
      this.GetType().Assembly.GetTypes()
          .Where(type => type.IsClass)
          .Where(type => type.Name.EndsWith("ViewModel", StringComparison.InvariantCulture))
          .ToList()
          .ForEach(viewModelType => this.container.RegisterPerRequest(
              viewModelType, viewModelType.ToString(), viewModelType));
    }

    /// <inheritdoc/>
    protected override void OnStartup(object sender, StartupEventArgs e)
    {
      this.DisplayRootViewFor<MainViewModel>();
    }

    /// <inheritdoc/>
    protected override object GetInstance(Type service, string key)
    {
      return this.container.GetInstance(service, key);
    }

    /// <inheritdoc/>
    protected override IEnumerable<object> GetAllInstances(Type service)
    {
      return this.container.GetAllInstances(service);
    }

    /// <inheritdoc/>
    protected override void BuildUp(object instance)
    {
      this.container.BuildUp(instance);
    }
  }
}
