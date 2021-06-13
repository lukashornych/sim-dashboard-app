namespace dashboardapp.data_readers
{
    public class TestDataGenerator
    {
        private int testSpeed;
        private int testRpm;
        private int testGear;
        private int testBlinkers;
        private int test;

        private int speedDir;
        private int rpmDir;

        public int Speed { get { return testSpeed; } }
        public int Rpm { get { return testRpm; } }
        public int Gear { get { return testGear; } }
        public int Blinkers { get { return testBlinkers; } }
        public int Test { get { return test; } }

        /// <summary>
        /// Generate next/new values for test
        /// </summary>
        public void GenerateNextValues()
        {
            testSpeed += 15 * speedDir;
            testRpm += 500 * rpmDir;

            if (testSpeed >= 300)
                speedDir = -1;
            else if (testSpeed <= 0)
                speedDir = 1;

            if (testRpm >= 10000)
                rpmDir = -1;
            else if (testRpm <= 0)
                rpmDir = 1;

            testGear = (testGear < 6) ? testGear + 1 : -1;
            testBlinkers = (testBlinkers < 2) ? testBlinkers + 1 : 0;
            test = (test < 1) ? test + 1 : 0;
        }
    }
}
