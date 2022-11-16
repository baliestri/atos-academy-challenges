// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

namespace Challenge02;

internal static class Program {
  [STAThread]
  private static void Main() {
    ApplicationConfiguration.Initialize();
    Application.Run(new MainForm());
  }
}
