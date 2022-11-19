// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.Reflection;
using Challenge02.Database;
using Challenge02.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Challenge02;

internal static class Program {
  private static readonly IHost _host;

  public static IServiceProvider Services => _host.Services;

  static Program() =>
    _host = createHostBuilder()
      .Build();

  [STAThread]
  private static void Main() {
    ApplicationConfiguration.Initialize();
    var entryPointForm = Services.GetRequiredService<EntryPointForm>();

    Application.Run(entryPointForm);

    if (entryPointForm.IsAuthenticated) {
      Application.Run(Services.GetRequiredService<MainForm>());
    }
  }

  private static IHostBuilder createHostBuilder() =>
    Host.CreateDefaultBuilder()
      .ConfigureHostConfiguration(x => x.AddUserSecrets(Assembly.GetExecutingAssembly()))
      .ConfigureLogging((_, logging) => {
        var logger = new LoggerConfiguration()
          .WriteTo.File(Path.Join(AppContext.BaseDirectory, "logs", "log-.txt"), LogEventLevel.Information,
            rollingInterval: RollingInterval.Hour)
          .WriteTo.File(Path.Join(AppContext.BaseDirectory, "logs", "log-error-.txt"), LogEventLevel.Error,
            rollingInterval: RollingInterval.Hour)
          .CreateLogger();

        logging.ClearProviders();
        logging.AddSerilog(logger);
      })
      .ConfigureServices((hostContext, services) => {
        services
          .AddTransient<EntryPointForm>()
          .AddTransient<MainForm>()
          .AddTransient<QueryForm>()
          .AddTransient<CreateCategoryForm>()
          .AddTransient<EditCategoryForm>()
          .AddTransient<CreateCustomerForm>()
          .AddTransient<EditCustomerForm>()
          .AddTransient<CreateSupplierForm>()
          .AddTransient<EditSupplierForm>()
          .AddTransient<CreateShipperForm>()
          .AddTransient<EditShipperForm>()
          .AddTransient<CreateOrderForm>()
          .AddTransient<EmitInvoiceForm>();

        services
          .AddSingleton(_ => new SqlConnection(hostContext.Configuration["ConnectionStrings:MSSQL"]))
          .AddSingleton<DatabaseContext>();
      });
}
