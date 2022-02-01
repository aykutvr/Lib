using System;
using System.ComponentModel;
using System.Text;

public static partial class Extensions
{
    public static void ReportProgress(this BackgroundWorker bgw, int position)
    {
        bgw.ReportProgress(position);
    }
    public static void ReportProgress(this BackgroundWorker bgw, int position, int maxValue)
    {
        if (maxValue != 0)
        {
            bgw.ReportProgress((position / maxValue) * 100);
        }
    }
    public static void ReportProgress(this BackgroundWorker bgw, int position, object userState)
    {

        bgw.ReportProgress(position, userState);

    }
    public static void ReportProgress(this BackgroundWorker bgw, int position, int maxValue, object userState)
    {
        if (maxValue != 0)
        {
            double dblPosition = Convert.ToDouble(position);
            double dblMaxValue = Convert.ToDouble(maxValue);
            double dblPercent = (dblPosition / dblMaxValue) * 100;
            bgw.ReportProgress(Convert.ToInt32(dblPercent), userState);
        }
    }
}
