using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdrianoAutoApp {
  static class HostLogic {

    static string hostFilePath = Environment
      .GetFolderPath(Environment.SpecialFolder.Windows) + @"\System32\Drivers\Etc\Hosts";

    public enum PorgramSupport {
      ADOBLE_PHOTOSHOP,
      COREL_DRAW,
      LUMION
    }

    public static void ApplyLogic(PorgramSupport program) {
      var hostContent = File.ReadAllText(hostFilePath);

      switch (program) {
        case PorgramSupport.ADOBLE_PHOTOSHOP:
          if (!hostContent.Contains("#Adobe Photoshop")) {
            File.AppendAllText(hostFilePath, "\n\n" + Properties.Resources.Adobe + "\n");
          }
          break;
        case PorgramSupport.COREL_DRAW:
          if (!hostContent.Contains("#CorelDraw")) {
            File.AppendAllText(hostFilePath, "\n\n" + Properties.Resources.CorelDraw + "\n");
          }
          break;
        case PorgramSupport.LUMION:
          if (!hostContent.Contains("#Lumion")) {
            File.AppendAllText(hostFilePath, "\n\n" + Properties.Resources.Lumion + "\n");
          }
          break;
      }
    }
  }
}
