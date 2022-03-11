using FastReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class CustomReport : FastReport.Report
    {
        public CustomReport() : base()
        {
            FastReport.Utils.Config.ReportSettings.ShowProgress = false;
            FastReport.Utils.Config.ReportSettings.ShowPerformance = false;
            FastReport.Utils.Config.WebMode = true;
        }

        public bool Prepare(string segundaViaObjectName = null)
        {
            segundaViaObjectName = segundaViaObjectName ?? "segundaVia";
            if (base.PrintSettings.Copies == 0)
                base.PrintSettings.Copies = 1;
            else { }
            for (int i = 0; i < base.PrintSettings.Copies; i++)
            {
                if (i == (base.PrintSettings.Copies - 1))
                {
                    try
                    {
                        ((ComponentBase)Report.FindObject(segundaViaObjectName)).Visible = true;
                    }
                    catch { }
                    base.Prepare(true);
                }
                else
                {
                    try
                    {
                        ((ComponentBase)Report.FindObject(segundaViaObjectName)).Visible = false;
                    }
                    catch { }
                    base.Prepare();
                }
            }
            return true;
        }
    }
}
