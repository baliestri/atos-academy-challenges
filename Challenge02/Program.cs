// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.Reflection;
using Challenge02.Database;
using Challenge02.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Templates;

namespace Challenge02;

internal static class Program {
  private static readonly IHost _host;

  static Program() =>
    _host = createHostBuilder()
      .Build();

  public static IServiceProvider Services => _host.Services;

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
      .ConfigureLogging(
        (_, logging) => {
          var logger = new LoggerConfiguration()
            .WriteTo.File(
              new ExpressionTemplate(
                "[{UtcDateTime(@t):o} {@l:u3} {#if SourceContext is not null} ({SourceContext}){#end}] {@m}\n{@x}"
              ),
              Path.Join(AppContext.BaseDirectory, "logs", "log-.txt"),
              rollingInterval: RollingInterval.Hour
            )
            .CreateLogger();

          logging.ClearProviders();
          logging.AddSerilog(logger);
        }
      )
      .ConfigureServices(
        (hostContext, services) => {
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
            .AddTransient<CreateProductForm>()
            .AddTransient<EditProductForm>()
            .AddTransient<EmitInvoiceForm>();

          services
            .AddDbContext<AppDbContext>(
              config
                => config.UseSqlServer(hostContext.Configuration["ConnectionStrings:MSSQL"])
            );
        }
      );
}
