using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAY_Obstacle_Height_Calculation
{
    internal class OHCInputClass
    {
        [Serializable]
        public class ObstacleInfo
        {
            public string LatObs { get; set; }
            public string LongObs { get; set; }
            public string FY { get; set; }
            public string ObsType { get; set; }
            public string PlotNo { get; set; }
            public string Designation { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string LocalLevel{ get; set; }
            public string WardNo { get; set; }
            public string Tole { get; set; }
            public string RLPlinthObs { get; set; }
            public string HAbovePlinthObs { get; set; }
            public string DateOfLetter { get; set; }
            public string DateOfPrevLetter { get; set; }
            public string RefNoPrevLetter { get; set; }
            public string LocalLevelNepali { get; set; }



            public string SurfaceName { get; set; }
            public string SurfaceHeight { get; set; }
            public string ElevationAllow { get; set; }
            public string ElevationOfObs { get; set; }
            public string PermittedElev { get; set; }
            public string AirportCode { get; set; }
            public string ArealDistance { get; set; }
            public string PlotCase { get; set; }
            public string OtherInfo { get; set; }
            public string LatRWY { get; set; }
            public string LongRWY { get; set; }
            public string TitleOfReport { get; set; }
            public string CalculationDetail { get; set; }
        }
    }
}
