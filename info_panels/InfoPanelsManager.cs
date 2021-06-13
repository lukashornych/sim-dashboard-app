using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dashboardapp.info_panels
{
    public class InfoPanelsManager
    {
        private AcInfoWindow acWindow;
        private AtsInfoWindow atsWindow;
        private PcarsInfoWindow pCarsWindow;
        private TestInfoWindow testWindow;

        private data_classes.AcDataClass acData;
        private data_classes.AtsDataClass atsData;
        private data_classes.PcarsDataClass pCarsData;
        private data_classes.TestDataClass testData;

        public InfoPanelsManager(data_classes.AcDataClass acData, data_classes.AtsDataClass atsData, data_classes.PcarsDataClass pCarsData, data_classes.TestDataClass testData)
        {
            this.acData = acData;
            this.atsData = atsData;
            this.pCarsData = pCarsData;
            this.testData = testData;
        }

        /// <summary>
        /// Open info panel for selected game
        /// </summary>
        /// <param name="selectedGame">Selected game</param>
        public void OpenInfoPanel(string selectedGame)
        {
            switch(selectedGame)
            {
                case "ac":
                    if(acWindow == null)
                    {
                        acWindow = new AcInfoWindow(acData);
                        acWindow.Show();
                    }
                    break;
                case "ats":
                    if(atsWindow == null)
                    {
                        atsWindow = new AtsInfoWindow(atsData);
                        atsWindow.Show();
                    }
                    break;
                case "pcars":
                    if(pCarsWindow == null)
                    {
                        pCarsWindow = new PcarsInfoWindow(pCarsData);
                        pCarsWindow.Show();
                    }
                    break;
                case "test":
                    if(testWindow == null)
                    {
                        testWindow = new TestInfoWindow(testData);
                        testWindow.Show();
                    }
                    break;
            }
        }

        /// <summary>
        /// Close info panel for selected game
        /// </summary>
        /// <param name="selectedGame">Selected game</param>
        public void CloseInfoPanels()
        {
            if (acWindow != null)
                acWindow.Close();

            if (atsWindow != null)
                atsWindow.Close();

            if (pCarsWindow != null)
                pCarsWindow.Close();

            if (testWindow != null)
                testWindow.Close();
        }
    }
}
